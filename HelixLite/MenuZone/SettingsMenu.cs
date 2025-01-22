using System;
using System.Runtime.CompilerServices;
using Exploits;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using Resources;
using UnityEngine;

namespace MenuZone
{
	// Token: 0x02000022 RID: 34
	[NullableContext(1)]
	[Nullable(0)]
	internal class SettingsMenu
	{
		// Token: 0x0600008F RID: 143 RVA: 0x000069A8 File Offset: 0x00004BA8
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			UiManager helixLiteModule = MenuManager.HelixLiteModule;
			ReMenuCategory reMenuCategory = Manager.QMMenu.AddCategoryPage("l Settings l", "", MenuIcon, "#ffffff").AddCategory("Wooooow We Love Eden");
			SettingsMenu.EspButton = reMenuCategory.AddButton("<color=white>ESP</color>", "Esp", delegate
			{
				ConfigZone.ESPBool.Value = !ConfigZone.ESPBool.Value;
				if (ConfigZone.ESPBool.Value)
				{
					SettingsMenu.EspButton.Text = "<color=green>ESP</color>";
					ESP.CapsuleAll(true);
					return;
				}
				SettingsMenu.EspButton.Text = "<color=white>ESP</color>";
				ESP.destroyesp();
			}, null, "#ffffff");
			SettingsMenu.NeonEspButton = reMenuCategory.AddButton("<color=white>NeonMode</color>", "neonEsp", delegate
			{
				ConfigZone.NeonESPBool.Value = !ConfigZone.NeonESPBool.Value;
				if (ConfigZone.NeonESPBool.Value)
				{
					SettingsMenu.NeonEspButton.Text = "<color=green>NeonMode</color>";
					if (ConfigZone.NeonESPBool.Value)
					{
						ESP.destroyesp();
						ESP.CapsuleAll(true);
						return;
					}
				}
				else
				{
					SettingsMenu.NeonEspButton.Text = "<color=white>NeonMode</color>";
					if (ConfigZone.NeonESPBool.Value)
					{
						ESP.destroyesp();
						ESP.CapsuleAll(true);
					}
				}
			}, null, "#ffffff");
			reMenuCategory.AddSpacer(null);
			reMenuCategory.AddSpacer(null);
			SettingsMenu.NamePlatesButton = reMenuCategory.AddButton("<color=white>Custom\nNamePlate</color>", "Custname", delegate
			{
				ConfigZone.NamePlateBool.Value = !ConfigZone.NamePlateBool.Value;
				if (ConfigZone.NamePlateBool.Value)
				{
					SettingsMenu.NamePlatesButton.Text = "<color=green>Custom\nNamePlate</color>";
					Misc.EnableAllNamePlates();
					return;
				}
				SettingsMenu.NamePlatesButton.Text = "<color=white>Custom\nNamePlate</color>";
				Misc.DisableAllNamePlates();
			}, null, "#ffffff");
			SettingsMenu.SpoofNameButton = reMenuCategory.AddButton("<color=white>Spoof\nName</color>", "Spoof\nName", delegate
			{
				ConfigZone.SpoofName.Value = !ConfigZone.SpoofName.Value;
				if (ConfigZone.SpoofName.Value)
				{
					SettingsMenu.SpoofNameButton.Text = "<color=green>Spoof\nName</color>";
					Misc.EnableAllNamePlates();
					return;
				}
				SettingsMenu.SpoofNameButton.Text = "<color=white>Spoof\nName</color>";
				Misc.DisableAllNamePlates();
			}, null, "#ffffff");
		}

		// Token: 0x0400008A RID: 138
		public static ReMenuButton NeonEspButton;

		// Token: 0x0400008B RID: 139
		public static ReMenuButton EspButton;

		// Token: 0x0400008C RID: 140
		public static ReMenuButton ItemEspButton;

		// Token: 0x0400008D RID: 141
		public static ReMenuButton NamePlatesButton;

		// Token: 0x0400008E RID: 142
		public static ReMenuButton SpoofNameButton;
	}
}
