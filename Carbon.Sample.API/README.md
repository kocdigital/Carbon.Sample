# **CarbonSampleAPI**

# **CarbonSampleAPI for Dotnet 5**

**Version 1.1.0**

**13.01.2021**

# Glossary

**SampleApi:** Implements some Carbon Framework features to be referred by anyone who wants to build a brand new api from the stracth.

**TimescaleDb:** Implements Repository Design Pattern to connect an SQL-based environment (TSDB) by using EntityFramework core

**Http.Auth:** Implements an identity server connection to easily communicate with other Platform360 APIs.

**MassTransit:** Capable of implementing RabbitMq. Simply remove comment section in Startup.cs

**Kubernetes:** Implements any prerequisites to be kubernetes enabled

# Sample codes as below

Platform360 Service SDK is implemented by MQTT. To develop a very simple "Hello, world!" MQTT client for Platform360, you need to follow these steps:

Please look for details about Mqtt Client Options classified below: [**Mqtt Client Options**](#_Glossary).

#### Node.js Example
```js
    var sdk = require("kocdigital-platform360-service-sdk-nodejs");

    // Build-in Logger's configurations
    sdk.Logger.Enabled = true;//Default
    sdk.Logger.Sources = [sdk.LogSource.Console];
    sdk.Logger.Level = sdk.LogLevel.Warn;//Default = LogLevel.Info

    let options = new sdk.MqttClient.MqttClientOptionsBuilder()
        .WithClientId("#CSEId")
        .WithCSEId("#ClientId")
        .WithOptions("#MqttPointOfAccess", #MqttPort, new TimeSpan(#TimeOut),"#MqttUserName", "#MqttPassword")
        .Build();

    // Create Enrollment Service to Enroll Device
    var enrollmentService = sdk.Factories.EnrollmentServiceFactory.CreateEnrollmentService(options);

    // Create Device Service to Use Device Functionalities
    var deviceService = sdk.Factories.DeviceServiceFactory.CreateDeviceService(options);

    // Create Device Management Service to Use Device Management Objects
    var deviceManagementService = sdk.Factories.DeviceManagementServiceFactory.CreateDeviceManagementService(options);

    (async () => {

    // It's important to cach all rejectsions within a async request, otherwise app can crash.

    //Enables create event notifications for all device enrollment operations
    //Uses enrollment service, calling this method one time is enough for lifetime
    //When you want to disable notifications, use DisableDeviceEnrollmentNotifications() method
    //await service.DisableDeviceEnrollmentNotifications();
    await service.EnableDeviceEnrollmentNotifications({
        NotificationUris: []//If you want to notify external apis
    }).catch(reason => { console.log(reason) });


    //Event handler for enrollment events
    /*
    operation types:
    Update = 1,
    DirectDelete = 2,
    Create = 3,
    ChildDelete = 4 
     */
    deviceService.UseDeviceModificationNotificationHandler(x => {
        console.log(`New device enrolled with 
        deviceId: ${x.DeviceId}, 
        deviceResourceId: ${x.DeviceResourceId}, 
        DeviceName: ${x.DeviceName}, 
        Operation: ${sdk.Service.Contracts.NotificationType[x.Operation]},
        Attributes: ${JSON.stringify(Array.from(x.Attributes))}`);
    });

    // Get a empty device Id from platform. Use this id for enrollment operation
    // For a successfull request you can get Id with deviceIdResult.DeviceId property
    let deviceIdResult = await enrollmentService.GetAvailableDeviceId();
    if (!deviceIdResult.IsSuccess) {
        Logger.Danger("Cannot Get Empty Id From Platform!");
        return;
    }

    let userDefinedAttributes = new Map();
    userDefinedAttributes.set("TestKey","TestValue");
    // It creates a device on the platform.
    // You can add Attributes as Key, Value pairs like MyId: 123 as ["MyId", "123"]
    let enrolmentResult = await enrollmentService.EnrollDeviceAsync({
        DeviceName: "test-device-1",
        DeviceId: deviceIdResult.DeviceId,
        Attributes: userDefinedAttributes
    }).catch(reason => { console.log(reason) });

    // Get Devices with Labels/Attributes
    var deviceResult = await deviceService.GetDevicesByLabel({Labels : [
        { Key: "TestKey", Values: ["TestValue"]}
    ]})
    .catch((reason) => { console.log(reason) });

    // Get All Registered Devices
    var allDevicesResult = await deviceService.GetAllDevices()
    .catch((reason) => { console.log(reason) });

    //For sending notifications related to sensor crud operations 
    //use EnableSensorModificationNotifications method.
    //Enabling it once for a sensor enough.
    //When you want to disable sensor crud notifications for a device
    //use DisableSensorModificationNotifications({DeviceResourceId: deviceResourceId}) 
    await service.EnableSensorModificationNotifications({
        DeviceResourceId: enrolmentResult.DeviceResourceId,
        NotificationUris: []//If you want to notify external apis
    }).catch(reason => { console.log(reason) });


    //Event handler for sensor crud events
    //Triggers when a new sensor created or deleted or updated
    /*
    operation types:
    Update = 1,
    DirectDelete = 2,
    Create = 3,
    ChildDelete = 4 
     */
    service.UseSensorModificationNotificationHandler(x => {
        console.log(`Sensor based operation occured for device  
        DeviceResourceId: ${x.DeviceResourceId}, with
        SensorResourceId: ${x.SensorResourceId}, 
        SensorName: ${x.SensorName}, 
        IsBidirectional: ${x.IsBidirectional}, 
        Operation: ${sdk.Service.Contracts.NotificationType[x.Operation]}`);
    });

    // Sensor Creation
    // Parameters: DeviceResourceId, Sensor Name and isBidirectional as an object parameneter and
    // another object with a function named GetPoA for notifications. When a command received there will be post request to this url
    let sensorResult = await deviceService.CreateSensorAsync({
        DeviceResourceId: enrolmentResult.DeviceResourceId,
        IsBidirectional: true,
        SensorName: "BidirectionalSensor---1"
    }, { GetPoA: () => "http://example.com/api/postme" }).catch(reason => { console.log(reason) });

    // Sensors retrieval by name 
    // Parameters: DeviceResourceId, List of Sensor Names.
    // Retrieves sensors with given exact names for a given device 
    let sensors = await deviceService.GetSensorsByName(        
        enrolmentResult.DeviceResourceId,
        ["BidirectionalSensor---1"]
    )
    .catch(reason => { console.log(reason) });

    // Device Service Connection to Platform
    // Here related resources and properties are loaded to device service objects
    await deviceService.ConnectToPlatformAsync([enrolmentResult.DeviceId]);

    deviceService.UseSensorValueChangeRequestHandler(x => {
        //You can ack or nack a message 
        x.Ack();
        //x.Nack();
        console.log(`Value comes from device: ${x.DeviceId}, sensor: ${x.SensorId}, from topic: ${x.Topic}, which Created at: ${x.CreationTime}, with value ${JSON.stringify(x.Message)}`);
    });

    // It sends the request to platform to save sensor data. Note that: this methot is a fire and forget type method, this means there will be no response
    deviceService.PushAndForgetSensorActualDataToPlatformAsync({
        DeviceId:  enrolmentResult.DeviceResourceId,
        SensorId: sensorResult.SensorId,
        CreationTime: new Date(),
        DataUnit: "Celcius",
        ExtractedData: "25"
    });

    // It sends the request to platform to save sensor data as a command, like changing sensor&#39;s value. We can handle this request at above, in UseSensorValueChangeRequestHandler event.
    await deviceService.PushAndForgetSensorDesiredDataToPlatformAsync({
        DeviceId:  enrolmentResult.DeviceResourceId,
        SensorId: sensorResult.SensorId,
        CreationTime: new Date(),
        DataUnit: "Celcius",
        ExtractedData: "27"
    }).catch((a) => console.log(a.message));


    //Normaly with PushSensorDesiredDataToPlatformAsync method we send request 
    //and when platform handles request, it sends a response
    //But with PushSensorDesiredDataAndWaitAckAsync method we wait ack or nack from 
    //a sdk. When a sdk handles a message with UseSensorValueChangeRequestHandler
    //please use Ack or Nack method for returning response, otherwise waiting part throws timeout error
    var serviceResult = await service.PushSensorDesiredDataAndWaitAckAsync({
        DeviceId:  enrolmentResult.DeviceResourceId,
        SensorId: sensorResult.SensorId,
        CreationTime: new Date(),
        DataUnit: "Celcius",
        ExtractedData: "25"
    });

    let battery = new sdk.Service.Contracts.DeviceManagement.DeviceBatteryCreateRequest();
    battery.DeviceId = enrolmentResult.DeviceId;
    battery.BatteryLevel = 10;
    battery.BatteryStatus = sdk.OneM2M.Constants.Management.BatteryStatus.LowBattery
    battery.Name = "DeviceBattery";

    let batteryBackup = new sdk.Service.Contracts.DeviceManagement.DeviceBatteryCreateRequest();
    batteryBackup.DeviceId = enrolmentResult.DeviceId;
    batteryBackup.BatteryLevel = 100;
    batteryBackup.BatteryStatus = sdk.OneM2M.Constants.Management.BatteryStatus.Normal;
    batteryBackup.Name = "DeviceSecondBattery";

    // Device Management Service Connection to Platform
    // Here related resources and properties are loaded to device management service object
    await deviceManagementService.ConnectToPlatformAsync([enrolmentResult.DeviceId]);
    let batteryResult = await deviceManagementService.CreateBatteryAsync(battery);
    let batteryBackupResult = await deviceManagementService.CreateBatteryAsync(batteryBackup);
    let batteries = await deviceManagementService.GetBatteriesAsync(enrolmentResult.DeviceId);

    console.log(batteryResult);
    console.log(batteryBackupResult);
    console.log(batteries);
})();
```
