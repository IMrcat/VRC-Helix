using System;
using System.Collections;
using System.Runtime.CompilerServices;
using MelonLoader;
using Resources;
using Resources.CustomShit;
using UnityEngine;
using VRC.SDKBase;

namespace HelixLiteModule
{
	// Token: 0x02000024 RID: 36
	[NullableContext(1)]
	[Nullable(0)]
	public static class SpoofName
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00006D5D File Offset: 0x00004F5D
		public static IEnumerator SetDisplayNameCoroutine()
		{
			float startTime = Time.time;
			if (ConfigZone.SpoofName.Value)
			{
				bool flageden = false;
				while (Time.time < startTime + 2f)
				{
					yield return null;
				}
				startTime = Time.time;
				int num = 0;
				while (num < 200)
				{
					try
					{
						string text = RoomManager.field_Private_Static_ApiWorldInstance_1.world.authorName;
						if (RoomManager.field_Private_Static_ApiWorldInstance_1.id.Contains("wrld_e6569266-21cd-4275-8aef-47fcb7458931"))
						{
							text = "TheProfessorNA";
						}
						bool flag = !string.IsNullOrEmpty(text);
						if (SpoofName.CustomInput != "")
						{
							text = SpoofName.CustomInput;
						}
						if (flag && Networking.LocalPlayer != null)
						{
							Networking.LocalPlayer.displayName = text;
							SpoofName.NameInUse = text;
							if (!flageden)
							{
								flageden = true;
								MelonLogger.Msg("Changed Name!  " + text);
							}
						}
						goto IL_012B;
					}
					catch
					{
						goto IL_012B;
					}
					goto IL_0114;
					IL_012B:
					if (Time.time >= startTime + 12f)
					{
						startTime = Time.time;
						int num2 = num;
						num = num2 + 1;
						continue;
					}
					IL_0114:
					yield return null;
					goto IL_012B;
				}
				yield break;
			}
			SpoofName.NameInUse = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.displayName;
			yield break;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006D68 File Offset: 0x00004F68
		public static async void SetNameSpecific()
		{
			string text = await InputBox.Create("Set Spoof Name", "Leave blank to set as default!", "Send", false, "");
			MelonLogger.Msg("User Input for spoof name: " + text);
			SpoofName.CustomInput = text;
		}

		// Token: 0x04000094 RID: 148
		public static string NameInUse = null;

		// Token: 0x04000095 RID: 149
		public static string CustomInput = "";
	}
}
