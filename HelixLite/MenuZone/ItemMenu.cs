using System;
using System.Runtime.CompilerServices;
using Exploits;
using MelonLoader;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using UnityEngine;

namespace MenuZone
{
	// Token: 0x0200001C RID: 28
	[NullableContext(1)]
	[Nullable(0)]
	internal class ItemMenu
	{
		// Token: 0x0600007B RID: 123 RVA: 0x00005318 File Offset: 0x00003518
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			UiManager helixLiteModule = MenuManager.HelixLiteModule;
			ReCategoryPage reCategoryPage = Manager.QMMenu.AddCategoryPage("l Items l", "", MenuIcon, "#ffffff");
			ReMenuCategory reMenuCategory = reCategoryPage.AddCategory("The Item Zone");
			ItemIndex.MakeMenu(ref reMenuCategory);
			ItemMenu.ReloadItems = reMenuCategory.AddButton("Reload", "Reloads the lsit of items", delegate
			{
				GeneralPickups.ReloadPickupList();
			}, ButtonIcon, "#ffffff");
			ItemMenu.RespawnItems = reMenuCategory.AddButton("Respawn", "Respawns all pickups!", delegate
			{
				GeneralPickups.RespawnPickups();
			}, ButtonIcon, "#ffffff");
			ItemMenu.VanishItems = reMenuCategory.AddButton("Vanish", "Sends Items To Infinity", delegate
			{
				GeneralPickups.VanishItems();
			}, ButtonIcon, "#ffffff");
			ItemMenu.ItemFreeze = reMenuCategory.AddButton("Drop Loop", "Will make them constantly drop the item", delegate
			{
				GeneralPickups.FreezeItems(null);
			}, ButtonIcon, "#ffffff");
			ItemMenu.RespawnLoop = reMenuCategory.AddButton("Respawn Loop", "Will constantly send the items back to their origin", delegate
			{
				GeneralPickups.VanishItems();
			}, ButtonIcon, "#ffffff");
			ItemMenu.DropItems = reMenuCategory.AddButton("Drop Items", "Butter Fingers", delegate
			{
				GeneralPickups.DropItems();
			}, ButtonIcon, "#ffffff");
			ReMenuCategory reMenuCategory2 = reCategoryPage.AddCategory("Item Gravity Zone");
			ItemMenu.GravityToggle = reMenuCategory2.AddButton("Toggle\n<color=red>off", "Toggle Item Gravity", delegate
			{
				ItemGravity.GravityToggleBool = !ItemGravity.GravityToggleBool;
				if (ItemGravity.GravityToggleBool)
				{
					ItemMenu.GravityToggle.Text = "Toggle\n<color=green>on";
					MelonCoroutines.Start(ItemGravity.GravityIntensity());
					return;
				}
				ItemMenu.GravityToggle.Text = "Toggle\n<color=red>off";
			}, ButtonIcon, "#ffffff");
			ItemMenu.ResetGravity = reMenuCategory2.AddButton("Reset Gravity", "Reset Values", delegate
			{
				ItemMenu.Slider1.Slide(1f, true);
				MelonCoroutines.Start(ItemGravity.ResetGravity());
			}, ButtonIcon, "#ffffff");
			ItemMenu.Slider1 = reCategoryPage.AddSliderCategory("Item Gravity Slider Zone").AddSlider("Gravity Strength", "Change gravity strength", delegate(float value)
			{
				ItemGravity.GravityIntensityValue = value;
			}, 1f, -3f, 3f, "#ffffff");
		}

		// Token: 0x04000062 RID: 98
		public static ReMenuButton ReloadItems;

		// Token: 0x04000063 RID: 99
		public static ReMenuButton RespawnItems;

		// Token: 0x04000064 RID: 100
		public static ReMenuButton VanishItems;

		// Token: 0x04000065 RID: 101
		public static ReMenuButton ItemFreeze;

		// Token: 0x04000066 RID: 102
		public static ReMenuButton RespawnLoop;

		// Token: 0x04000067 RID: 103
		public static ReMenuButton DropItems;

		// Token: 0x04000068 RID: 104
		public static ReMenuButton GravityToggle;

		// Token: 0x04000069 RID: 105
		public static ReMenuButton ResetGravity;

		// Token: 0x0400006A RID: 106
		public static ReMenuButton ResetFrequency;

		// Token: 0x0400006B RID: 107
		private static ReMenuSlider Slider1;

		// Token: 0x0400006C RID: 108
		private static ReMenuSlider Slider2;
	}
}
