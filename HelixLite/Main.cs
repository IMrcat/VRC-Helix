using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Exploits;
using HelixLite.Exploits;
using HelixLiteModule.Components;
using MelonLoader;
using MenuZone;
using Movement;
using Resources;
using Resources.PatchZone;
using Toast;
using UnhollowerRuntimeLib;
using UnityEngine;
using Values;
using VRC.UI.Elements;

namespace HelixLiteModule
{
	// Token: 0x02000025 RID: 37
	[NullableContext(1)]
	[Nullable(0)]
	public class Main : MelonMod
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00006DA9 File Offset: 0x00004FA9
		public static void commononsceneload()
		{
			Murder4.Utils.OnMurderJoin();
			GeneralPickups.AllItems = null;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006DB8 File Offset: 0x00004FB8
		public static IEnumerator WaitForQuickMenu()
		{
			while (Object.FindObjectOfType<QuickMenu>() == null)
			{
				yield return null;
			}
			MenuManager.Start();
			Patch.MakeHooks();
			yield break;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006DC0 File Offset: 0x00004FC0
		public override void OnApplicationStart()
		{
			ConfigZone.OnStart();
			ClassInjector.RegisterTypeInIl2Cpp<CustomNameplate>();
			Patch.StartPatches();
			MelonCoroutines.Start(Main.WaitForQuickMenu());
			Binds.Register();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006DE1 File Offset: 0x00004FE1
		public override void OnInitializeMelon()
		{
			Screen.fullScreenMode = 2;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006DE9 File Offset: 0x00004FE9
		public override void OnApplicationQuit()
		{
			base.OnApplicationQuit();
			MelonPreferences.Save();
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006E00 File Offset: 0x00005000
		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			LocalUser.Loadedin = false;
			Main.LoadedIntoWorld = false;
			MelonCoroutines.Start(SpoofName.SetDisplayNameCoroutine());
			base.OnSceneWasLoaded(buildIndex, sceneName);
			MelonCoroutines.Start(Main.LoadIntoWorldCheck());
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006E2C File Offset: 0x0000502C
		public static IEnumerator LoadIntoWorldCheck()
		{
			float startTime = Time.time;
			while (!Main.LoadedIntoWorld)
			{
				VRCPlayer field_Internal_Static_VRCPlayer_ = VRCPlayer.field_Internal_Static_VRCPlayer_0;
				if (((field_Internal_Static_VRCPlayer_ != null) ? field_Internal_Static_VRCPlayer_.field_Private_VRCPlayerApi_0 : null) != null)
				{
					if (RoomManager.field_Private_Static_ApiWorldInstance_1 != null)
					{
						LocalUser.OrigionalGravity = Physics.gravity;
						LocalUser.OrigionalWalkSpeed = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.GetWalkSpeed();
						LocalUser.OrigionalStrafeSpeed = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.GetStrafeSpeed();
						LocalUser.OrigionalRunSpeed = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.GetRunSpeed();
						LocalUser.OrigionalJumpheight = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.GetJumpImpulse();
						Main.LoadedIntoWorld = true;
						while (Time.time < startTime + 7f)
						{
							yield return null;
						}
						startTime = Time.time;
						Main.commononsceneload();
						RunJump.SetMovementValue(ConfigZone.MovementSpeed.Value);
						RunJump.SetJumpHeightValue(ConfigZone.JumpHeight.Value);
						StepHeight.SetIfWasSet();
						if (!Main.FirstLoad)
						{
							Main.FirstLoad = true;
							continue;
						}
						continue;
					}
				}
				while (Time.time < startTime + 1f)
				{
					yield return null;
				}
				startTime = Time.time;
			}
			yield break;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006E34 File Offset: 0x00005034
		public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
		{
			base.OnSceneWasUnloaded(buildIndex, sceneName);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006E3E File Offset: 0x0000503E
		public override void OnFixedUpdate()
		{
			Flight.FlyUpdate();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00006E45 File Offset: 0x00005045
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (Main.LoadedIntoWorld)
			{
				Jetpack.Update();
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00006E59 File Offset: 0x00005059
		public override void OnLateUpdate()
		{
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00006E5B File Offset: 0x0000505B
		public static IEnumerator Drinknightretardfix()
		{
			yield return new WaitForSeconds(4f);
			int x = 0;
			while (x != 6)
			{
				GameObject gameObject = GameObject.Find("Poof Go The Clients");
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
					x = 6;
					ToastNotif.Toast("Drinking Night", "Prevented World From Crashing You!!", null, 2f);
				}
				else
				{
					int num = x;
					x = num + 1;
				}
				yield return new WaitForSeconds(1f);
			}
			yield break;
		}

		// Token: 0x04000096 RID: 150
		public static bool LoadedIntoWorld;

		// Token: 0x04000097 RID: 151
		private static bool FirstLoad;

		// Token: 0x04000098 RID: 152
		private static string string1;
	}
}
