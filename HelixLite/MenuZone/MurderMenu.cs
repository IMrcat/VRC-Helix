using System;
using System.Runtime.CompilerServices;
using HelixLite.Exploits;
using MelonLoader;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;
using UnityEngine;
using Values;
using VRC;

namespace MenuZone
{
	// Token: 0x0200001F RID: 31
	[NullableContext(1)]
	[Nullable(0)]
	internal class MurderMenu
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00005BF8 File Offset: 0x00003DF8
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			UiManager helixLiteModule = MenuManager.HelixLiteModule;
			ReCategoryPage reCategoryPage = Manager.QMMenu.AddCategoryPage("l Murder l", "", MenuIcon, "#ffffff");
			ReMenuCategory reMenuCategory = reCategoryPage.AddCategory("Game Logic & General");
			reMenuCategory.AddButton("Start Game", "Start Game", delegate
			{
				Murder4.General.StartGame();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Bystander Win", "Bystander Win", delegate
			{
				Murder4.General.BystanderWin();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Murder Win", "Murder Win", delegate
			{
				Murder4.General.MurderWin();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Abort", "Abort", delegate
			{
				Murder4.General.Abort();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Lights On", "Lights On", delegate
			{
				Murder4.General.MurderLightsOn();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Lights Off", "Lights Off", delegate
			{
				Murder4.General.MurderLightsOff();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Explode Gun", "Explode Gun", delegate
			{
				Murder4.General.ExplodeGun();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Smoke Gun", "Smoke Gun", delegate
			{
				Murder4.General.SmokeGun();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Flash All", "Flash All", delegate
			{
				Murder4.General.FlashAll();
			}, null, "#ffffff");
			MurderMenu.LoopRole = reMenuCategory.AddButton("Loop All", "Loop All", delegate
			{
				Murder4.Target.TargetLoop = !Murder4.Target.TargetLoop;
				if (Murder4.Target.TargetLoop)
				{
					foreach (Player player in others.GetAllPlayers())
					{
						if (player.field_Private_VRCPlayerApi_0.displayName != VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.displayName)
						{
							MelonCoroutines.Start(Murder4.Target.TargetLoopPlayer(player._vrcplayer));
						}
					}
					MurderMenu.LoopRole.Text = "<color=green>Loop All";
					return;
				}
				MurderMenu.LoopRole.Text = "<color=red>Loop All";
			}, null, "#ffffff");
			ReMenuCategory reMenuCategory2 = reCategoryPage.AddCategory("Doors");
			reMenuCategory2.AddButton("Doors ON (Local)", "Fuck this thing is in my way", delegate
			{
				GameObject.Find("Environment/Doors").transform.position = new Vector3(0f, 0f, 0f);
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Doors OFF (Local)", "Yey no obsticals", delegate
			{
				GameObject.Find("Environment/Doors").transform.position = new Vector3(0f, 200f, 0f);
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Open", "Open", delegate
			{
				Murder4.Utils.DoorEvent("Interact open");
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Close", "Close", delegate
			{
				Murder4.Utils.DoorEvent("Interact close");
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Lock", "Lock", delegate
			{
				Murder4.Utils.DoorEvent("Interact lock");
			}, null, "#ffffff");
			reMenuCategory2.AddButton("UN-Lock", "UN-Lock", delegate
			{
				Murder4.Utils.DoorEvent("Interact shove");
				Murder4.Utils.DoorEvent("Interact shove");
				Murder4.Utils.DoorEvent("Interact shove");
				Murder4.Utils.DoorEvent("Interact shove");
			}, null, "#ffffff");
			MurderMenu.AutoLockLoop = reMenuCategory2.AddButton("Lock Loop", "Keeps all doors closed", delegate
			{
				Murder4.General.AutoLockDoorsbool = !Murder4.General.AutoLockDoorsbool;
				if (Murder4.General.AutoLockDoorsbool)
				{
					MelonCoroutines.Start(Murder4.General.AutoLockDoors());
					MurderMenu.AutoLockLoop.Text = "<color=green>Lock Loop</color>";
					return;
				}
				MurderMenu.AutoLockLoop.Text = "<color=red>Lock Loop</color>";
			}, null, "#ffffff");
			ReMenuCategory reMenuCategory3 = reCategoryPage.AddCategory("BearTrap");
			reMenuCategory3.AddButton("Trap Detective", "Trap Detective", delegate
			{
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (0)"), new Vector3(4.931f, 3.107f, 127.691f));
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (0)"), new Vector3(4.931f, 3.107f, 127.691f));
			}, null, "#ffffff");
			reMenuCategory3.AddButton("Trap Stair 1", "Trap Stair 1", delegate
			{
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (2)"), new Vector3(-2.994f, 2.995f, 121.689f));
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (2)"), new Vector3(-2.994f, 2.995f, 121.689f));
			}, null, "#ffffff");
			reMenuCategory3.AddButton("Trap Stair 2", "Trap Stair 2", delegate
			{
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (1)"), new Vector3(5.022f, 0.068f, 135.853f));
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (1)"), new Vector3(5.022f, 0.068f, 135.853f));
			}, null, "#ffffff");
			reMenuCategory3.AddButton("Trap Bedroom", "Trap Bedroom", delegate
			{
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (0)"), new Vector3(-4.489f, 3.047f, 129.285f));
				Murder4.General.beartrapsmover(GameObject.Find("Bear Trap (0)"), new Vector3(-4.489f, 3.047f, 129.285f));
			}, null, "#ffffff");
			ReMenuPage reMenuPage = Manager.TargetMenu.AddMenuPage("l Target Murder l", "", null, "#ffffff");
			reMenuPage.AddButton("<color=green>Bystander", "<color=green>Bystander", delegate
			{
				Murder4.Target.SetBystander(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuPage.AddButton("<color=blue>Detective", "<color=blue>Detective", delegate
			{
				Murder4.Target.SetDetective(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuPage.AddButton("<color=red>Murderer", "<color=red>Murderer", delegate
			{
				Murder4.Target.SetMurderer(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuPage.AddButton("Sync Kill", "Sync Kill", delegate
			{
				Murder4.Target.ForceKill(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuPage.AddButton("Shoot", "Sync Kill", delegate
			{
				MelonCoroutines.Start(Murder4.Target.Targetfirerevolver(PlayerExtensions.GetVRCPlayer()));
			}, null, "#ffffff");
			reMenuPage.AddButton("Explode", "Sync Kill", delegate
			{
				Murder4.Target.TargetExplode(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuPage.AddButton("Smoke", "Sync Kill", delegate
			{
				Murder4.Target.TargetSmoke(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			MurderMenu.MurderTargetDoorAnoyyance = reMenuPage.AddButton("Annoying Doors\nClick2Add", "Annoying Doors\nClick2Add", delegate
			{
				Murder4.Target.doorannoyancemode = true;
				MelonCoroutines.Start(Murder4.Target.DoorAnnoyance(PlayerExtensions.GetVRCPlayer()));
				MurderMenu.MurderTargetDoorAnoyyance.Text = "<color=green>Annoying Doors</color>";
			}, null, "#ffffff");
			reMenuPage.AddButton("Stop Annoying Doors", "Stop Annoying Doors", delegate
			{
				Murder4.Target.doorannoyancemode = false;
			}, null, "#ffffff");
			reMenuPage.AddButton("Add Loop", "Target Loop", delegate
			{
				Murder4.Target.TargetLoop = true;
				MelonCoroutines.Start(Murder4.Target.TargetLoopPlayer(PlayerExtensions.GetVRCPlayer()));
			}, null, "#ffffff");
			reMenuPage.AddButton("Stop All Loop", "Target Loop", delegate
			{
				Murder4.Target.TargetLoop = false;
			}, null, "#ffffff");
		}

		// Token: 0x0400007A RID: 122
		public static ReMenuButton AutoLockLoop;

		// Token: 0x0400007B RID: 123
		public static ReMenuButton LoopRole;

		// Token: 0x0400007C RID: 124
		public static ReMenuButton MurderTargetDoorAnoyyance;
	}
}
