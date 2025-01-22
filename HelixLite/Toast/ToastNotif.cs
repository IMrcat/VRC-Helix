using System;
using System.Collections;
using System.Runtime.CompilerServices;
using MelonLoader;
using UnityEngine;
using VRC.Localization;

namespace Toast
{
	// Token: 0x0200000B RID: 11
	[NullableContext(1)]
	[Nullable(0)]
	internal class ToastNotif
	{
		// Token: 0x06000021 RID: 33 RVA: 0x0000294C File Offset: 0x00000B4C
		public static void Toast(string content, string description = null, Sprite icon = null, float duration = 5f)
		{
			LocalizableString localizableString = LocalizableStringExtensions.Localize(content, null, null, null);
			LocalizableString localizableString2 = LocalizableStringExtensions.Localize(description, null, null, null);
			VRCUiManager.field_Private_Static_VRCUiManager_0.field_Private_HudController_0.notification.Method_Public_Void_Sprite_LocalizableString_LocalizableString_Single_Object1PublicTYBoTYUnique_1_Boolean_0(icon, localizableString, localizableString2, duration, null);
			MelonLogger.Msg(string.Concat(new string[] { "\n", content, "\n", description, "\n\n" }));
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000029B6 File Offset: 0x00000BB6
		public static IEnumerator DelayToast(float delay, string content, string description = null, Sprite icon = null, float duration = 5f)
		{
			float startTime = Time.time;
			while (Time.time < startTime + delay)
			{
				yield return null;
			}
			startTime = Time.time;
			LocalizableString localizableString = LocalizableStringExtensions.Localize(content, null, null, null);
			LocalizableString localizableString2 = LocalizableStringExtensions.Localize(description, null, null, null);
			VRCUiManager.field_Private_Static_VRCUiManager_0.field_Private_HudController_0.notification.Method_Public_Void_Sprite_LocalizableString_LocalizableString_Single_Object1PublicTYBoTYUnique_1_Boolean_0(icon, localizableString, localizableString2, duration, null);
			MelonLogger.Msg(string.Concat(new string[] { "\n", content, "\n", description, "\n\n" }));
			yield break;
		}
	}
}
