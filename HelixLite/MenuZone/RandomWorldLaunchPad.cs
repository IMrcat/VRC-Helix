using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using Resources;
using UnityEngine;
using Values;
using VRC.Core;
using VRC.SDKBase;

namespace MenuZone
{
	// Token: 0x02000021 RID: 33
	[NullableContext(1)]
	[Nullable(0)]
	internal class RandomWorldLaunchPad
	{
		// Token: 0x06000087 RID: 135 RVA: 0x0000634C File Offset: 0x0000454C
		public static void Create(ref UiManager Manager)
		{
			ReCategoryPage reCategoryPage = MenuManager.HelixLiteModule.LaunchPad.AddCategoryPage("Join Worlds", "", null, "#ffffff");
			ReMenuCategory reMenuCategory = reCategoryPage.AddCategory("Worlds");
			RandomWorldLaunchPad.World1 = reMenuCategory.AddButton("world1", "World1", delegate
			{
				KeyValuePair<string, int> keyValuePair = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(0);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair.Key, keyValuePair.Value);
			}, null, "#ffffff");
			RandomWorldLaunchPad.World2 = reMenuCategory.AddButton("World2", "World2", delegate
			{
				KeyValuePair<string, int> keyValuePair2 = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(1);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair2.Key, keyValuePair2.Value);
			}, null, "#ffffff");
			RandomWorldLaunchPad.World3 = reMenuCategory.AddButton("World3", "World3", delegate
			{
				KeyValuePair<string, int> keyValuePair3 = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(2);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair3.Key, keyValuePair3.Value);
			}, null, "#ffffff");
			RandomWorldLaunchPad.World4 = reMenuCategory.AddButton("World4", "World4", delegate
			{
				KeyValuePair<string, int> keyValuePair4 = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(3);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair4.Key, keyValuePair4.Value);
			}, null, "#ffffff");
			RandomWorldLaunchPad.World5 = reMenuCategory.AddButton("World5", "World5", delegate
			{
				KeyValuePair<string, int> keyValuePair5 = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(4);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair5.Key, keyValuePair5.Value);
			}, null, "#ffffff");
			RandomWorldLaunchPad.World6 = reMenuCategory.AddButton("World6", "World6", delegate
			{
				KeyValuePair<string, int> keyValuePair6 = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(5);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair6.Key, keyValuePair6.Value);
			}, null, "#ffffff");
			RandomWorldLaunchPad.World7 = reMenuCategory.AddButton("World7", "World7", delegate
			{
				KeyValuePair<string, int> keyValuePair7 = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(6);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair7.Key, keyValuePair7.Value);
			}, null, "#ffffff");
			RandomWorldLaunchPad.World8 = reMenuCategory.AddButton("World8", "World8", delegate
			{
				KeyValuePair<string, int> keyValuePair8 = RandomWorldLaunchPad.WorldInfoDictionary.ElementAt(7);
				RandomWorldLaunchPad.JoinRandomRoom(keyValuePair8.Key, keyValuePair8.Value);
			}, null, "#ffffff");
			ReMenuCategory reMenuCategory2 = reCategoryPage.AddCategory("Settings");
			RandomWorldLaunchPad.GroupOrPubButton = reMenuCategory2.AddButton("<color=white>Public\n&\nGroups", "<color=white>Public\n&\nGroups", delegate
			{
				ConfigZone.PublicAndGroups.Value = !ConfigZone.PublicAndGroups.Value;
				if (ConfigZone.PublicAndGroups.Value)
				{
					RandomWorldLaunchPad.GroupOrPubButton.Text = "<color=white>Public\n&\nGroups";
					RandomWorldLaunchPad.GroupOrPubButton.Tooltip = "<color=white>Public\n&\nGroups";
					return;
				}
				RandomWorldLaunchPad.GroupOrPubButton.Text = "<color=white>Public\nOnly";
				RandomWorldLaunchPad.GroupOrPubButton.Tooltip = "<color=white>Public\nOnly";
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Update", "Update", delegate
			{
				RandomWorldLaunchPad.UpdateButtonNames();
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Clear Previously Joined", "Update", delegate
			{
				RandomWorldLaunchPad.WorldList.Clear();
			}, null, "#ffffff");
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006604 File Offset: 0x00004804
		private static void UpdateButtonNames()
		{
			RandomWorldLaunchPad.WorldInfoDictionary.Clear();
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World1.Value, ref RandomWorldLaunchPad.World1);
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World2.Value, ref RandomWorldLaunchPad.World2);
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World3.Value, ref RandomWorldLaunchPad.World3);
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World4.Value, ref RandomWorldLaunchPad.World4);
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World5.Value, ref RandomWorldLaunchPad.World5);
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World6.Value, ref RandomWorldLaunchPad.World6);
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World7.Value, ref RandomWorldLaunchPad.World7);
			RandomWorldLaunchPad.UpdateWorld(ConfigZone.World8.Value, ref RandomWorldLaunchPad.World8);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000066BC File Offset: 0x000048BC
		private static void UpdateWorld(string configValue, ref ReMenuButton worldButton)
		{
			string[] array = RandomWorldLaunchPad.SeperateShit(configValue, '|');
			worldButton.Text = array[0];
			worldButton.Tooltip = array[0];
			int num = (int.TryParse(array[2], out num) ? num : 5);
			RandomWorldLaunchPad.WorldInfoDictionary.Add(array[1], num);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006705 File Offset: 0x00004905
		private static string[] SeperateShit(string Input, char SeperateBy)
		{
			return Input.Replace(" ", string.Empty).Split(new char[] { SeperateBy });
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006728 File Offset: 0x00004928
		public static void JoinRandomRoom(string targetworld, int MinPlayers)
		{
			RandomWorldLaunchPad.UpdateButtonNames();
			List<ApiWorldInstance> mWorldInstances = RoomManager.field_Internal_Static_ApiWorld_0.mWorldInstances;
			string id = RoomManager.field_Private_Static_ApiWorldInstance_1.id;
			MelonLogger.Msg(targetworld);
			if (!RoomManager.field_Private_Static_ApiWorldInstance_1.worldId.Contains(targetworld))
			{
				MelonCoroutines.Start(RandomWorldLaunchPad.JoinEmptyFirst(targetworld, MinPlayers));
				return;
			}
			if (!RandomWorldLaunchPad.WorldList.Contains(id))
			{
				RandomWorldLaunchPad.WorldList.Add(id);
			}
			if (mWorldInstances.Count > 0)
			{
				foreach (ApiWorldInstance apiWorldInstance in mWorldInstances)
				{
					if (!RandomWorldLaunchPad.WorldList.Contains(apiWorldInstance.id) && (apiWorldInstance.type == null || (ConfigZone.PublicAndGroups.Value && apiWorldInstance.type == 5)) && apiWorldInstance.count > MinPlayers)
					{
						RandomWorldLaunchPad.Log("Joining Random World");
						Networking.GoToRoom(apiWorldInstance.id);
						RandomWorldLaunchPad.WorldList.Add(apiWorldInstance.id);
						break;
					}
				}
			}
			if (RoomManager.field_Internal_Static_ApiWorld_0.mWorldInstances.Count > 0)
			{
				foreach (ApiWorldInstance apiWorldInstance2 in mWorldInstances)
				{
					if (!RandomWorldLaunchPad.WorldList.Contains(apiWorldInstance2.id) && (apiWorldInstance2.type == null || (ConfigZone.PublicAndGroups.Value && apiWorldInstance2.type == 5)) && apiWorldInstance2.count > MinPlayers)
					{
						RandomWorldLaunchPad.Log("Found World");
						Networking.GoToRoom(apiWorldInstance2.id);
						RandomWorldLaunchPad.WorldList.Add(apiWorldInstance2.id);
						return;
					}
				}
				return;
			}
			RandomWorldLaunchPad.Log("\n\n\ninstances empty or not enough players!\ngoing random potentially empty world instead!\n\n\n");
			if (mWorldInstances.Count > 0)
			{
				foreach (ApiWorldInstance apiWorldInstance3 in mWorldInstances)
				{
					if (!RandomWorldLaunchPad.WorldList.Contains(apiWorldInstance3.id) && (apiWorldInstance3.type == null || (ConfigZone.PublicAndGroups.Value && apiWorldInstance3.type == 5)))
					{
						RandomWorldLaunchPad.Log("Joining Random World no player limit");
						Networking.GoToRoom(apiWorldInstance3.id);
						RandomWorldLaunchPad.WorldList.Add(apiWorldInstance3.id);
						return;
					}
				}
				return;
			}
			RandomWorldLaunchPad.Log("couldnt find a lobby with even 1 player...");
			Networking.GoToRoom(targetworld + ":1111");
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000695F File Offset: 0x00004B5F
		private static IEnumerator JoinEmptyFirst(string target, int minplayers)
		{
			float startTime = Time.time;
			MelonLogger.Msg("Going to empty first! - Sorry!!!");
			Networking.GoToRoom(target + ":1111");
			while (Time.time < startTime + 15f)
			{
				yield return null;
			}
			startTime = Time.time;
			while (!LocalUser.Loadedin)
			{
				while (Time.time < startTime + 0.2f)
				{
					yield return null;
				}
				startTime = Time.time;
			}
			while (Time.time < startTime + 1f)
			{
				yield return null;
			}
			startTime = Time.time;
			RandomWorldLaunchPad.JoinRandomRoom(target, minplayers);
			yield break;
		}

		// Token: 0x0400007E RID: 126
		private static ReMenuButton World1;

		// Token: 0x0400007F RID: 127
		private static ReMenuButton World2;

		// Token: 0x04000080 RID: 128
		private static ReMenuButton World3;

		// Token: 0x04000081 RID: 129
		private static ReMenuButton World4;

		// Token: 0x04000082 RID: 130
		private static ReMenuButton World5;

		// Token: 0x04000083 RID: 131
		private static ReMenuButton World6;

		// Token: 0x04000084 RID: 132
		private static ReMenuButton World7;

		// Token: 0x04000085 RID: 133
		private static ReMenuButton World8;

		// Token: 0x04000086 RID: 134
		private static ReMenuButton GroupOrPubButton;

		// Token: 0x04000087 RID: 135
		private static Dictionary<string, int> WorldInfoDictionary = new Dictionary<string, int>();

		// Token: 0x04000088 RID: 136
		private static Action<string> Log = delegate(string message)
		{
			MelonLogger.Msg(message);
		};

		// Token: 0x04000089 RID: 137
		public static List<string> WorldList = new List<string>();
	}
}
