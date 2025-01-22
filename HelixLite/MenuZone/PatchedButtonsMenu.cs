using System;
using System.Runtime.CompilerServices;
using ReMod.Core.Managers;
using UnityEngine;

namespace MenuZone
{
	// Token: 0x02000020 RID: 32
	internal class PatchedButtonsMenu
	{
		// Token: 0x06000085 RID: 133 RVA: 0x00006333 File Offset: 0x00004533
		[NullableContext(1)]
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			UiManager helixLiteModule = MenuManager.HelixLiteModule;
			bool compatabilityMode = PatchedButtonsMenu.CompatabilityMode;
		}

		// Token: 0x0400007D RID: 125
		public static bool CompatabilityMode;
	}
}
