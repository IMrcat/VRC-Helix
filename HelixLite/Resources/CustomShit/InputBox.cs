using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using VRC.Localization;
using VRC.UI.Elements.Controls;

namespace Resources.CustomShit
{
	// Token: 0x02000011 RID: 17
	internal class InputBox
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00003D9C File Offset: 0x00001F9C
		[NullableContext(1)]
		public static async Task<string> Create(string Title, string Placeholder, string ButonText, bool Numberkeyboard = false, string FilledText = "")
		{
			TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
			string userInput = "";
			Action<string, List<KeyCode>, TextMeshProUGUIEx> action = delegate(string s, List<KeyCode> k, TextMeshProUGUIEx t)
			{
				if (string.IsNullOrEmpty(s))
				{
					tcs.SetResult("");
					return;
				}
				userInput = s;
				tcs.SetResult(userInput);
			};
			VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_LocalizableString_LocalizableString_InputType_Boolean_LocalizableString_Action_3_String_List_1_KeyCode_TextMeshProUGUIEx_LocalizableString_Boolean_Action_1_VRCUiPopup_PDM_0(LocalizableStringExtensions.Localize(Title, null, null, null), LocalizableStringExtensions.Localize(FilledText, null, null, null), 0, Numberkeyboard, LocalizableStringExtensions.Localize(ButonText, null, null, null), action, LocalizableStringExtensions.Localize(Placeholder, null, null, null), true, null);
			return await tcs.Task;
		}
	}
}
