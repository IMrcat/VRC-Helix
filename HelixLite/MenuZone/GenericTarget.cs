using System;
using System.Runtime.CompilerServices;
using Exploits;
using ReMod.Core.Managers;
using ReMod.Core.VRChat;
using UnityEngine;

namespace MenuZone
{
	// Token: 0x0200001B RID: 27
	internal class GenericTarget
	{
		// Token: 0x06000079 RID: 121 RVA: 0x000052C0 File Offset: 0x000034C0
		[NullableContext(1)]
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			UiManager helixLiteModule = MenuManager.HelixLiteModule;
			Manager.TargetMenu.AddButton("lLewdifyl", "lewdify Target", delegate
			{
				ForceLewd.LewdPlayer(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
		}
	}
}
