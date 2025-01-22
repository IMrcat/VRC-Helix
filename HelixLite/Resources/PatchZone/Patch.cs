using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Exploits;
using Harmony;
using HarmonyLib;
using HelixLiteModule.Components;
using Il2CppSystem;
using MelonLoader;
using PatchZone;
using Photon.Realtime;
using Toast;
using UnhollowerBaseLib;
using UnityEngine;
using Values;
using VRC;
using VRC.Core;
using VRC.Economy.Internal;
using VRC.Networking;
using VRC.SDKBase;
using VRC.UI.Elements;

namespace Resources.PatchZone
{
	// Token: 0x0200000E RID: 14
	[NullableContext(1)]
	[Nullable(0)]
	internal class Patch
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00002DBC File Offset: 0x00000FBC
		public static void MakeHooks()
		{
			NetworkManager.field_Internal_Static_NetworkManager_0.OnPlayerJoinedDelegate.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(Patch.OnPlayerJoin));
			NetworkManager.field_Internal_Static_NetworkManager_0.OnPlayerLeaveDelegate.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(Patch.OnPlayerLeft));
			MelonLogger.Msg("Hooked The Fish!");
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E1F File Offset: 0x0000101F
		private static void Hook(ref bool __0)
		{
			__0 = true;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002E24 File Offset: 0x00001024
		public static void StartPatches()
		{
			try
			{
				Patch.instance.Patch(typeof(APIUser).GetProperty("allowAvatarCopying").GetSetMethod(), new HarmonyMethod(typeof(Patch).GetMethod("Hook", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
				MelonLogger.Msg("[Helix] Force Clone Patched");
			}
			catch (Exception ex)
			{
				MelonLogger.Msg(ex);
			}
			try
			{
				Patch.instance.Patch(typeof(QuickMenu).GetMethod("OnDisable"), new HarmonyMethod(typeof(Patch).GetMethod("OnMenuClosed", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
				MelonLogger.Msg("[Helix] MenuClose patched!");
			}
			catch (Exception ex2)
			{
				string text = "[Helix] MenuClose Failed to patch!!!! ";
				Exception ex3 = ex2;
				MelonLogger.Msg(text + ((ex3 != null) ? ex3.ToString() : null));
			}
			try
			{
				Patch.instance.Patch(typeof(QuickMenu).GetMethod("OnEnable"), new HarmonyMethod(typeof(Patch).GetMethod("OnMenuOpened", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
				MelonLogger.Msg("[Helix] MenuOpen patched!");
			}
			catch (Exception ex4)
			{
				string text2 = "[Helix] MenuOpen Failed to patch!!!! ";
				Exception ex5 = ex4;
				MelonLogger.Msg(text2 + ((ex5 != null) ? ex5.ToString() : null));
			}
			try
			{
				Patch.instance.Patch(typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC"), new HarmonyMethod(typeof(Patch).GetMethod("UdonPatch", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
				MelonLogger.Msg("[Helix] Udon patched!");
			}
			catch (Exception ex6)
			{
				string text3 = "[Helix] Udon Failed to patch!!!! ";
				Exception ex7 = ex6;
				MelonLogger.Msg(text3 + ((ex7 != null) ? ex7.ToString() : null));
			}
			try
			{
				Patch.instance.Patch(typeof(VRC_EventDispatcherRFC).GetMethod("Method_Public_Boolean_Player_VrcEvent_VrcBroadcastType_0"), new HarmonyMethod(typeof(Patch).GetMethod("RPCPatch", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
				MelonLogger.Msg("[Helix] RPC patched?!");
			}
			catch
			{
			}
			try
			{
				Patch.instance.Patch(typeof(LoadBalancingClient).GetMethods().LastOrDefault((MethodInfo x) => x.Name.Equals("OnEvent")), new HarmonyMethod(AccessTools.Method(typeof(Patch), "OnEvent", null, null)), null, null, null, null);
				MelonLogger.Msg("[Helix] OnEventRecieved patched!");
			}
			catch (Exception ex8)
			{
				string text4 = "[Helix] OnEventRecieved Failed to patch!!!! ";
				Exception ex9 = ex8;
				MelonLogger.Msg(text4 + ((ex9 != null) ? ex9.ToString() : null));
			}
			try
			{
				Patch.instance.Patch(typeof(LoadBalancingClient).GetMethod("Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0"), new HarmonyMethod(typeof(Patch).GetMethod("RaisedEvent", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
				MelonLogger.Msg("[Helix] RaisedEvent patched!");
			}
			catch (Exception ex10)
			{
				string text5 = "[Helix] RaisedEvent Failed to patch!!!! ";
				Exception ex11 = ex10;
				MelonLogger.Msg(text5 + ((ex11 != null) ? ex11.ToString() : null));
			}
			try
			{
				Patch.instance.Patch(typeof(VRCAvatarManager).GetMethod("Method_Private_Boolean_ApiAvatar_GameObject_0"), new HarmonyMethod(typeof(Patch).GetMethod("AvatarThing", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
				MelonLogger.Msg("[Helix] Avatarthing patched?!");
			}
			catch
			{
			}
			try
			{
				Patch.instance.Patch(typeof(Store).GetMethod("Method_Private_Boolean_VRCPlayerApi_IProduct_PDM_0"), Patch.GetPreFix("RetrunPrefix"), null, null, null, null);
				Patch.instance.Patch(typeof(Store).GetMethod("Method_Private_Boolean_IProduct_PDM_0"), Patch.GetPreFix("RetrunPrefix"), null, null, null, null);
			}
			catch
			{
				MelonLogger.Msg("Fuck ECoNOMY FAiaiIlaled");
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003230 File Offset: 0x00001430
		private static bool RPCPatch(Player param_1, VRC_EventHandler.VrcEvent param_2, VRC_EventHandler.VrcBroadcastType param_3)
		{
			try
			{
				if ((param_2.ParameterString == "MelonloaderRPC Funny Hehe" || param_2.ParameterObject.name == "MelonloaderRPC Funny Hehe") && param_1.field_Private_APIUser_0.id != APIUser.CurrentUser.id)
				{
					CustomNameplate customNameplate = CustomNameplate.FindById(param_1.field_Private_APIUser_0.id);
					if (customNameplate != null)
					{
						customNameplate.ishelixuser = true;
					}
				}
				if (param_2.ParameterObject.name == "MelonloaderRPC Funny Hehe" && (param_1.field_Private_APIUser_0.id == "usr_5b8191ef-29e5-44fb-9b1b-cc2b88c12bd8" || param_1.field_Private_APIUser_0.id == "usr_11f4f4f5-f69d-4771-b14a-29d8a3535f90" || param_1.field_Private_APIUser_0.id == "usr_34584e51-fb77-49f9-a0e5-b62160556a1f") && param_2.ParameterString != "MelonloaderRPC Funny Hehe")
				{
					ToastNotif.Toast("Message Recieved", param_2.ParameterString, null, 7f);
				}
			}
			catch (Exception ex)
			{
				MelonLogger.Msg(ex.ToString());
			}
			return true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003348 File Offset: 0x00001548
		private static HarmonyMethod GetPreFix(string methodName)
		{
			return new HarmonyMethod(typeof(Patch).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic));
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003361 File Offset: 0x00001561
		private static bool RetrunPrefix(ref bool __result)
		{
			__result = true;
			return false;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003368 File Offset: 0x00001568
		private static bool AvatarThing(ApiAvatar param_1, GameObject param_2)
		{
			if (Patch.avatarthing)
			{
				Player component = param_2.transform.parent.parent.GetComponent<Player>();
				if (component != null && component._vrcplayer.field_Private_VRCPlayerApi_0.displayName != VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.displayName && ForceLewd.autolewd)
				{
					ForceLewd.LewdPlayer(component._vrcplayer);
				}
			}
			return true;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000033D4 File Offset: 0x000015D4
		private static void OnMenuOpened()
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000033D6 File Offset: 0x000015D6
		private static void OnMenuClosed()
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000033D8 File Offset: 0x000015D8
		private static bool UdonPatch(string param_1, Player param_2)
		{
			if (string.IsNullOrEmpty(param_1))
			{
				MelonLogger.Msg("param1 is empty or null");
				return true;
			}
			if (param_2._vrcplayer == null)
			{
				MelonLogger.Msg("param2 is null");
				return true;
			}
			GodModeCheck.CheckGodMode(param_1, param_2);
			if (Patch.TestPilotsGod && TestPilots.JoinedSacc)
			{
				if (param_1.Contains("BulletDamage") || param_1.Contains("MissileHit") || param_1.Contains("Explode") || param_1.Contains("Hit") || param_1.Contains("Crash") || param_1.Contains("Damage") || param_1.Contains("Destroy") || param_1.Contains("EnterWater") || param_1.Contains("Missile"))
				{
					MelonLogger.Msg("Blocked: " + param_1);
					return false;
				}
				MelonLogger.Msg("Not Blocked: " + param_1);
				ToastNotif.Toast(param_1, null, null, 5f);
			}
			if (RoomManager.field_Private_Static_ApiWorldInstance_1.id.Contains("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe") || RoomManager.field_Private_Static_ApiWorldInstance_1.id.Contains("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
			{
				if (Patch.UdonBlockFlag && Time.time > Patch.timething + 60f)
				{
					Patch.UdonBlockFlag = false;
					Patch.timething = Time.time;
				}
				if ((param_1.Contains("SyncAssign") || param_1.Contains("SyncVotedOut") || param_1.Contains("SyncCountdown") || param_1.Contains("SyncVictory") || param_1.Contains("SyncAbort")) && !param_2.field_Private_VRCPlayerApi_0.isMaster && param_2.field_Private_APIUser_0.id != Player.Method_Internal_Static_get_Player_0().field_Private_APIUser_0.id)
				{
					if (!Patch.UdonBlockFlag)
					{
						Patch.UdonBlockFlag = true;
						Patch.timething = Time.time;
						ToastNotif.Toast("Client User", string.Concat(new string[]
						{
							"Blocked ",
							param_2.field_Private_APIUser_0.displayName,
							" From sending '",
							param_1,
							"'"
						}), null, 2f);
					}
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000035FC File Offset: 0x000017FC
		public static IEnumerator sendrpcdelayed(float delay, bool forcesend)
		{
			float startTime = Time.time;
			while (Time.time < startTime + delay)
			{
				yield return null;
			}
			startTime = Time.time;
			if (!forcesend)
			{
				while (Time.time < startTime + (Patch.lastrpctime + 15f))
				{
					Patch.lastrpctime = Time.time;
					yield return null;
				}
			}
			if (Patch.rpchandle == null)
			{
				Patch.rpchandle = new GameObject("MelonloaderRPC Funny Hehe");
			}
			Networking.RPC(0, Patch.rpchandle, "MelonloaderRPC Funny Hehe", new Il2CppReferenceArray<Object>(0L));
			yield break;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003614 File Offset: 0x00001814
		public static void OnPlayerJoin(Player player)
		{
			if (player.field_Private_APIUser_0.displayName == Player.Method_Internal_Static_get_Player_0().field_Private_APIUser_0.displayName)
			{
				LocalUser.OrigionalDisplayName = player.field_Private_APIUser_0.displayName;
				MelonCoroutines.Start(InstanceHistroy.SaveInstanceToHistory());
				TestPilots.FirstJoinLoad();
				RoomManager.field_Private_Static_ApiWorldInstance_1.id.Contains("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7");
				MelonCoroutines.Start(Patch.sendrpcdelayed(20f, true));
				try
				{
					if (ConfigZone.NamePlateBool.Value)
					{
						CustomNameplate nameplate2 = player.gameObject.AddComponent<CustomNameplate>();
						nameplate2.Player = player;
						Action<string> action = delegate(string s)
						{
						};
						Action<APIUser> action2 = delegate(APIUser s)
						{
							nameplate2.DateCreated = s.date_joined;
						};
						APIUser.FetchUser(player.field_Private_APIUser_0.id, action2, action);
					}
					return;
				}
				catch
				{
					return;
				}
			}
			MelonCoroutines.Start(Patch.sendrpcdelayed(20f, false));
			if (ConfigZone.NamePlateBool.Value)
			{
				CustomNameplate nameplate = player.gameObject.AddComponent<CustomNameplate>();
				nameplate.Player = player;
				Action<string> action3 = delegate(string s)
				{
				};
				Action<APIUser> action4 = delegate(APIUser s)
				{
					nameplate.DateCreated = s.date_joined;
				};
				APIUser.FetchUser(player.field_Private_APIUser_0.id, action4, action3);
			}
			if (ConfigZone.ESPBool.Value)
			{
				MelonCoroutines.Start(ESP.delayedstart(10f, player, true));
			}
			if (!Patch.edenjoined && player._vrcplayer._player.field_Private_APIUser_0.id == "usr_34584e51-fb77-49f9-a0e5-b62160556a1f")
			{
				MelonCoroutines.Start(ToastNotif.DelayToast(10f, "Helix Owner Joined", "EdenFailes joined", null, 7f));
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000380C File Offset: 0x00001A0C
		public static void OnPlayerLeft(Player player)
		{
			if (ConfigZone.NamePlateBool.Value)
			{
				CustomNameplate.PlayerLeft(player.field_Private_APIUser_0.id);
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000382A File Offset: 0x00001A2A
		private static bool RaisedEvent(ref byte param_1, ref Object param_2, RaiseEventOptions param_3, SendOptions param_4)
		{
			if (Patch.GhostMode && param_1 == 12)
			{
				if (Patch.GhostDebug)
				{
					ToastNotif.Toast("Serialize/Ghost Worked", "No one can see you move now", null, 3f);
					Patch.GhostDebug = false;
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000385E File Offset: 0x00001A5E
		internal static bool OnEvent(EventData param_1)
		{
			return true;
		}

		// Token: 0x04000033 RID: 51
		private static readonly global::HarmonyLib.Harmony instance = new global::HarmonyLib.Harmony("HelixLite");

		// Token: 0x04000034 RID: 52
		public static bool moderatorjoined = false;

		// Token: 0x04000035 RID: 53
		public static bool avatarthing = true;

		// Token: 0x04000036 RID: 54
		public static bool TestPilotsGod = false;

		// Token: 0x04000037 RID: 55
		public static bool UdonBlockFlag = false;

		// Token: 0x04000038 RID: 56
		private static float timething = Time.time;

		// Token: 0x04000039 RID: 57
		private static GameObject rpchandle = null;

		// Token: 0x0400003A RID: 58
		private static float lastrpctime = Time.time;

		// Token: 0x0400003B RID: 59
		private static bool edenjoined = false;

		// Token: 0x0400003C RID: 60
		public static bool GhostMode = false;

		// Token: 0x0400003D RID: 61
		public static bool GhostDebug = false;

		// Token: 0x0400003E RID: 62
		private static float TimeToCheck = Time.time;
	}
}
