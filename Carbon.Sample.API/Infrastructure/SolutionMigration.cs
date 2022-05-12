using Platform360.Domain.Messages.SolutionCreationSaga;

using System;
using System.Collections.Generic;

namespace Carbon.Sample.API.Infrastructure
{
	public static class SolutionMigration
	{
		public static List<FeatureSet> GetFeatureSetMigration()
		{
			/*
			 ****************************************************************
			 ****************************************************************
			 *																*
			 *																*
			 *		PLEASE USE NEW GUIDs, THOSE ARE JUST EXAMPLE			*
			 *																*
			 *																*
			 ****************************************************************
			 ****************************************************************
			*/
			List<FeatureSet> featureSets = new List<FeatureSet>();

			featureSets.Add(new FeatureSet()
			{
				FeatureSetId = new Guid("0C5B5758-E505-43FA-9385-56D93CC8497C"),
				FeatureSetName = "Sample API",
				Description = "Sample API",
				EndpointItemPermissions = new List<EndpointItemPermission>()
				{
					new EndpointItemPermission()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Code = "Sample_Read",
						Name = "Sample_Read",
						Id = new Guid("738B4777-5A3C-4EAC-80F1-F9E30F5D1CBC")
					},
					new EndpointItemPermission()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Code = "Sample_Create",
						Name = "Sample_Create",
						Id = new Guid("1399FBE9-F58F-4FD6-80A9-81E8B9FF40D2")
					},
					new EndpointItemPermission()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Code = "Sample_Update",
						Name = "Sample_Update",
						Id = new Guid("9CE86928-5117-458F-B8C7-AEFADF517FA7")
					},
					new EndpointItemPermission()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Code = "Sample_Delete",
						Name = "Sample_Delete",
						Id = new Guid("3B36A582-9570-4CF4-84FE-9FC7071A0858")
					}
				},
				MenuItemPermissions = new List<MenuItemPermission>()
				{
					new MenuItemPermission()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Code = "Sample API Edit",
						Name= "Sample API Edit",
						Id = new Guid("9A3C56A7-50A9-48CB-AE40-1883A5A5F9F4"),
						Uri = "/SampleEdit", Meta="{\"path\":\"/SampleEdit/:id\",\"remote\":\"$$p360micropage$$\",\"name\":\"project-sampleedit-remote\"}"
					},
					new MenuItemPermission()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Code = "Sample API List",
						Name = "Sample API List",
						Id = new Guid("4551B241-7BF6-468A-A666-8B9D26ED55BC"),
						Uri = "/SampleList", Meta = "{\"path\":\"/SampleList\",\"title\":{\"en\":\"Sample API\",\"tr\":\"Sample List\"},\"icon\":\"mdi-bell-alert-outline\",\"remote\":\"$$p360micropage$$\",\"name\":\"project-samplelist-remote\"}"
					},
					new MenuItemPermission()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Code = "Sample API Create",
						Name = "Sample API Create",
						Id = new Guid("64325492-457E-4E42-B462-D1295BBBE24C"),
						Uri = "/SampleCreate", Meta = "{\"path\":\"/SampleCreate\",\"remote\":\"$$p360micropage$$\",\"name\":\"project-samplecreate-remote\"}"
					}
				},
				UIItemPermissions = new List<UIItemPermission>()
				{

				},
				PermissionGroups = new List<PermissionGroup>()
				{
					new PermissionGroup()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Type = (PermissionGroupType)1,
						Name = "Sample API List",
						Id = new Guid("6D334EE2-45A8-412A-BE55-81571D803FD9")
					},
					new PermissionGroup()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Type = (PermissionGroupType)2,
						Name = "Sample API Create",
						Id = new Guid("72FFED08-2F14-49B6-A362-135C698C4FC4")
					},
					new PermissionGroup()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Type = (PermissionGroupType)3,
						Name = "Sample API Update",
						Id = new Guid("BB1EA163-5F74-42C7-9E0E-5ADD1682ABDD")
					},
					new PermissionGroup()
					{
						ApplicationId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268"),
						Type = (PermissionGroupType)4,
						Name = "Sample API Delete",
						Id = new Guid("1F7B0083-8C0E-43B3-A455-AF59AB6F024E")
					},
				},
				PermissionGroupEndpointItemPermissionRelations = new List<PermissionGroupEndpointItemPermissionRelation>()
				{
					//Read
					new PermissionGroupEndpointItemPermissionRelation()
					{
						PermissionGroupId = new Guid("6D334EE2-45A8-412A-BE55-81571D803FD9"),
						EndpointItemPermissionId = new Guid("738B4777-5A3C-4EAC-80F1-F9E30F5D1CBC"),
						Id = new Guid("75217F29-DD67-4782-A43E-3D600564D13F")
					},					

					//Create
					new PermissionGroupEndpointItemPermissionRelation()
					{
						PermissionGroupId = new Guid("72FFED08-2F14-49B6-A362-135C698C4FC4"),
						EndpointItemPermissionId = new Guid("1399FBE9-F58F-4FD6-80A9-81E8B9FF40D2"),
						Id = new Guid("F07DF1F3-DE80-42E1-9439-3B0830367434")
					},					

					//Update
					new PermissionGroupEndpointItemPermissionRelation()
					{
						PermissionGroupId = new Guid("BB1EA163-5F74-42C7-9E0E-5ADD1682ABDD"),
						EndpointItemPermissionId = new Guid("9CE86928-5117-458F-B8C7-AEFADF517FA7"),
						Id = new Guid("C82000FD-0F5D-4D41-9DDB-3DF466C5B0EF")
					},

					//Delete
					new PermissionGroupEndpointItemPermissionRelation()
					{
						PermissionGroupId = new Guid("1F7B0083-8C0E-43B3-A455-AF59AB6F024E"),
						EndpointItemPermissionId = new Guid("3B36A582-9570-4CF4-84FE-9FC7071A0858"),
						Id = new Guid("1E8AA2CA-3F84-4964-9BCE-D7802BDDD5BE")
					},
				},
				PermissionGroupMenuItemPermissionRelations = new List<PermissionGroupMenuItemPermissionRelation>()
				{
						new PermissionGroupMenuItemPermissionRelation()
						{
							PermissionGroupId = new Guid("6D334EE2-45A8-412A-BE55-81571D803FD9"),
							MenuItemPermissionId = new Guid("4551B241-7BF6-468A-A666-8B9D26ED55BC"),
							Id = new Guid("69D25BA2-A002-445E-8CF6-1A6E5F832191")
						},
						new PermissionGroupMenuItemPermissionRelation()
						{
							PermissionGroupId = new Guid("72FFED08-2F14-49B6-A362-135C698C4FC4"),
							MenuItemPermissionId = new Guid("64325492-457E-4E42-B462-D1295BBBE24C"),
							Id = new Guid("60D90924-2712-4218-9449-4DDC1B56EF13")
						},
						new PermissionGroupMenuItemPermissionRelation()
						{
							PermissionGroupId = new Guid("BB1EA163-5F74-42C7-9E0E-5ADD1682ABDD"),
							MenuItemPermissionId = new Guid("9A3C56A7-50A9-48CB-AE40-1883A5A5F9F4"),
							Id = new Guid("333E3FA1-95ED-4C2B-9FE9-D558B2A153E7")
						},
						new PermissionGroupMenuItemPermissionRelation()
						{
							PermissionGroupId = new Guid("1F7B0083-8C0E-43B3-A455-AF59AB6F024E"),
							MenuItemPermissionId = new Guid("4551B241-7BF6-468A-A666-8B9D26ED55BC"),
							Id = new Guid("4EEA6085-670B-40F4-8F7F-7EB1AAF31131")
						}
				},
				PermissionGroupUIItemPermissionRelations = new List<PermissionGroupUIItemPermissionRelation>()
				{

				},
				Features = new List<Feature>()
				{
					new Feature()
					{
						FeatureId = new Guid("20B1417F-C3DE-4B1A-99C6-DD3FED11D4BD"),
						FeatureName = "Sample API Basics",
						Description = "Sample API Basics",
						ApplicationFeaturePermissionGroups = new List<ApplicationFeaturePermissionGroupRelation>()
						{
							new ApplicationFeaturePermissionGroupRelation()
							{
								PermissionGroupId = new Guid("6D334EE2-45A8-412A-BE55-81571D803FD9"),
								ApplicationFeatureId = new Guid("20B1417F-C3DE-4B1A-99C6-DD3FED11D4BD"),
								Id = new Guid("91AA80F6-2F58-4D8F-857A-D359811E4090")
							},
							new ApplicationFeaturePermissionGroupRelation()
							{
								PermissionGroupId = new Guid("72FFED08-2F14-49B6-A362-135C698C4FC4"),
								ApplicationFeatureId = new Guid("20B1417F-C3DE-4B1A-99C6-DD3FED11D4BD"),
								Id = new Guid("623DF378-6378-4958-B58F-ED8E21867EDB")
							},
							new ApplicationFeaturePermissionGroupRelation()
							{
								PermissionGroupId = new Guid("BB1EA163-5F74-42C7-9E0E-5ADD1682ABDD"),
								ApplicationFeatureId = new Guid("20B1417F-C3DE-4B1A-99C6-DD3FED11D4BD"),
								Id = new Guid("A8EFA31D-99EE-4BCD-87BE-58A818739F2D")
							},
							new ApplicationFeaturePermissionGroupRelation()
							{
								PermissionGroupId = new Guid("1F7B0083-8C0E-43B3-A455-AF59AB6F024E"),
								ApplicationFeatureId = new Guid("20B1417F-C3DE-4B1A-99C6-DD3FED11D4BD"),
								Id = new Guid("FAFFFFB2-108C-4C61-B540-1387C6AA59C5")
							}
						}
					}
				},
				Version = 1 //If you edit those feature list, update version for automatic migrations
			});
			return featureSets;
		}
	}
}
