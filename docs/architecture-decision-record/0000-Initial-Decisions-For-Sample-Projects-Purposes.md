# Initial Decisions for Sample Project's Purposes
* Status: Accepted
* Deciders: TeamX Developer (Developer), Product Owner (Analyst), Kerem Aytaç (Architect), Anıl Eladağ (Architect)
* Date: 2021-12-28

## Context and Problem Statement

### This Section will be prepared by API owner, cross-checked and modified by Architects
* We want to access to timeserie data and retrieve them.
* Our sample api will communicate with Platform 360 Core Apis and call some external actions securely and send retrieved data from timeseriedb.
* We want to implement Carbon in this project.
* We want to use TimeScaleDb to be able to retrieve timeserie data.
* We want to be containerized and kubernetes enabled.
* Which packages should be adopted from Carbon Framework?
* How to communicate with P360 Core Apis?
* How to containerize our sample API?

## Considered Options

### This Section will be prepared by API owner, cross-checked and modified by Architects
* [1] [Carbon.Sample](http://bellatrix:8080/tfs/KocDigitalCollection/Carbon/_git/Carbon.Sample) may be used to create backbone and frame of our API.
* [2] [CarbonFramework](http://bellatrix:8080/tfs/KocDigitalCollection/Carbon/_git/Carbon) may the one which can be referred to as Carbon Repository.
* [3] [Carbon.TimeScaleDb](http://bellatrix:8080/tfs/KocDigitalCollection/Carbon/_git/Carbon?path=%2FCarbon.TimeScaleDb) - may be used in order to connect tsdb.
* [4] [Carbon.Http.Auth](http://bellatrix:8080/tfs/KocDigitalCollection/Carbon/_git/Carbon?path=%2FCarbon.HttpClient.Auth) - may be used in order to communicate with P360 Core Apis
* [5] [Carbon.WebApplication](http://bellatrix:8080/tfs/KocDigitalCollection/Carbon/_git/Carbon?path=%2FCarbon.WebApplication) may provide the KocDigital standards to our API including containerization as well.
* [6] RabbitMq may be used to have async communication between APIs.


## Decision Outcome
### This Section will be prepared by Architects

* [1 - 5] Accepted. [6] deferred for a later decision.
* [6] will be used when RabbitMq is needed.