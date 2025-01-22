using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using VRC;
using VRC.SDKBase;

namespace PatchZone
{
	// Token: 0x02000009 RID: 9
	[NullableContext(1)]
	[Nullable(0)]
	internal class GodModeCheck
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000026A0 File Offset: 0x000008A0
		public static bool CheckGodMode(string Udon, Player Player)
		{
			return !GodModeCheck.GodMode || Networking.LocalPlayer == VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0 || !GodModeCheck.GodCheckList.Any((string check) => Udon.Contains(check));
		}

		// Token: 0x0400000D RID: 13
		private static List<string> GodCheckList = new List<string> { "SyncKill", "KillLocalPlayer", "Explode", "Btn_Kill" };

		// Token: 0x0400000E RID: 14
		public static bool GodMode = false;
	}
}
