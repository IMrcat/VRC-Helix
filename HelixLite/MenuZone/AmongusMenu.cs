using System;
using System.Runtime.CompilerServices;
using Exploits;
using MelonLoader;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;
using Toast;
using UnityEngine;
using Values;
using VRC;

namespace MenuZone
{
	// Token: 0x02000018 RID: 24
	[NullableContext(1)]
	[Nullable(0)]
	internal class AmongusMenu
	{
		// Token: 0x06000072 RID: 114 RVA: 0x0000468C File Offset: 0x0000288C
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			UiManager helixLiteModule = MenuManager.HelixLiteModule;
			ReCategoryPage reCategoryPage = Manager.QMMenu.AddCategoryPage("l Amongus l", "", MenuIcon, "#ffffff");
			ReMenuCategory reMenuCategory = reCategoryPage.AddCategory("GenericShit");
			reMenuCategory.AddButton("Start Game", "", delegate
			{
				AmongusShit.Generic.StartGame();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Bystander Win", "", delegate
			{
				AmongusShit.Generic.BystanderWin();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Imposter Win", "", delegate
			{
				AmongusShit.Generic.SusWin();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Abort Game", "", delegate
			{
				AmongusShit.Generic.Abprt();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Start Meeting", "", delegate
			{
				AmongusShit.Generic.SyncEmergencyMeeting();
			}, null, "#ffffff");
			reMenuCategory.AddButton("End Voting", "", delegate
			{
				AmongusShit.Generic.SyncEndVotingPhase();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Vote Nobody (Sounds Annoying)", "", delegate
			{
				AmongusShit.Generic.SyncVoteResultNobody();
			}, null, "#ffffff");
			reMenuCategory.AddButton("Vote Skip", "", delegate
			{
				MelonCoroutines.Start(AmongusShit.Generic.SkipEveryone());
			}, null, "#ffffff");
			reMenuCategory.AddButton("Eject All", "", delegate
			{
				MelonCoroutines.Start(AmongusShit.Generic.EjectAll());
			}, null, "#ffffff");
			reMenuCategory.AddButton("Enable Vents", "will only enable for this round", delegate
			{
				AmongusShit.Generic.EnableVents();
			}, null, "#ffffff");
			AmongusMenu.loopallbutton = reMenuCategory.AddButton("LoopAll", "Will attempt to loop  everyone currently in the instance", delegate
			{
				AmongusShit.Target.TargetLoop = !AmongusShit.Target.TargetLoop;
				if (AmongusShit.Target.TargetLoop)
				{
					AmongusMenu.loopingall = true;
					AmongusMenu.loopallbutton.Text = "<color=green>LoopAll</color>";
					foreach (Player player in others.GetAllPlayers())
					{
						MelonCoroutines.Start(AmongusShit.Target.targetLoopPlayer(player._vrcplayer));
					}
					ToastNotif.Toast("Loop All", "All players currently here attempted to be looped", null, 5f);
					return;
				}
				AmongusMenu.loopingall = false;
				AmongusMenu.loopallbutton.Text = "LoopAll";
			}, null, "#ffffff");
			ReMenuCategory reMenuCategory2 = reCategoryPage.AddCategory("Doors");
			reMenuCategory2.AddButton("Upper", "", delegate
			{
				AmongusShit.Generic.UpperDoor();
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Lower", "", delegate
			{
				AmongusShit.Generic.LowerDoor();
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Medbay", "", delegate
			{
				AmongusShit.Generic.MedbadDoor();
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Security", "", delegate
			{
				AmongusShit.Generic.SecurityDoor();
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Cafateria", "", delegate
			{
				AmongusShit.Generic.CafeteriaDoor();
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Storage", "", delegate
			{
				AmongusShit.Generic.StorageDoor();
			}, null, "#ffffff");
			reMenuCategory2.AddButton("Electrical", "", delegate
			{
				AmongusShit.Generic.ElectricalDoor();
			}, null, "#ffffff");
			ReMenuCategory reMenuCategory3 = reCategoryPage.AddCategory("Sabotages");
			AmongusMenu.sabopage = reMenuCategory3.AddCategoryPage("Previous Sabotage", "", null, "#ffffff");
			ReMenuCategory reMenuCategory4 = AmongusMenu.sabopage.AddCategory("Generic");
			reMenuCategory4.AddButton("Trigger", "", delegate
			{
				AmongusMenu.ActionToUse();
			}, null, "#ffffff");
			reMenuCategory4.AddButton("Stop", "", delegate
			{
				AmongusMenu.ActionToStop();
			}, null, "#ffffff");
			ReMenuCategory reMenuCategory5 = AmongusMenu.sabopage.AddCategory("(Only For Oxygen)");
			reMenuCategory5.AddButton("Stop A", "", delegate
			{
				AmongusMenu.ActionA();
			}, null, "#ffffff");
			reMenuCategory5.AddButton("Stop B", "", delegate
			{
				AmongusMenu.ActionB();
			}, null, "#ffffff");
			reMenuCategory3.AddButton("Oxygen", "", delegate
			{
				AmongusMenu.ActionToUse = new Action(AmongusShit.Generic.Oxygen);
				AmongusMenu.ActionToStop = new Action(AmongusShit.Generic.SyncRepairOxygenAB);
				AmongusMenu.ActionA = new Action(AmongusShit.Generic.SyncRepairOxygenA);
				AmongusMenu.ActionB = new Action(AmongusShit.Generic.SyncRepairOxygenB);
				AmongusMenu.sabopage.Open();
			}, null, "#ffffff");
			reMenuCategory3.AddButton("Comms", "", delegate
			{
				AmongusMenu.ActionToUse = new Action(AmongusShit.Generic.Coms);
				AmongusMenu.ActionToStop = new Action(AmongusShit.Generic.SyncRepairComms);
				AmongusMenu.ActionA = null;
				AmongusMenu.ActionB = null;
				AmongusMenu.sabopage.Open();
			}, null, "#ffffff");
			reMenuCategory3.AddButton("Reactor", "", delegate
			{
				AmongusMenu.ActionToUse = new Action(AmongusShit.Generic.Reactor);
				AmongusMenu.ActionToStop = new Action(AmongusShit.Generic.SyncRepairReactor);
				AmongusMenu.ActionA = null;
				AmongusMenu.ActionB = null;
				AmongusMenu.sabopage.Open();
			}, null, "#ffffff");
			reMenuCategory3.AddButton("Lights", "", delegate
			{
				AmongusMenu.ActionToUse = new Action(AmongusShit.Generic.Lights);
				AmongusMenu.ActionToStop = new Action(AmongusShit.Generic.SyncRepairLights);
				AmongusMenu.ActionA = null;
				AmongusMenu.ActionB = null;
				AmongusMenu.sabopage.Open();
			}, null, "#ffffff");
			reMenuCategory3.AddButton("TriggerAll", "", delegate
			{
				AmongusShit.Generic.Lights();
				AmongusShit.Generic.Oxygen();
				AmongusShit.Generic.Coms();
				AmongusShit.Generic.Reactor();
			}, null, "#ffffff");
			reMenuCategory3.AddButton("StopAll", "", delegate
			{
				AmongusShit.Generic.StopSabbo();
			}, null, "#ffffff");
			ReCategoryPage reCategoryPage2 = Manager.TargetMenu.AddCategoryPage("l Amongus-Targ l", "", null, "#ffffff");
			ReMenuCategory reMenuCategory6 = reCategoryPage2.AddCategory("Roles");
			reMenuCategory6.AddButton("<color=green>Crew</color>", "", delegate
			{
				AmongusShit.Target.targetBystander(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuCategory6.AddButton("<color=red>Imposter</color>", "", delegate
			{
				AmongusShit.Target.targetSus(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			ReMenuCategory reMenuCategory7 = reCategoryPage2.AddCategory("OtherShit");
			reMenuCategory7.AddButton("Kill", "", delegate
			{
				AmongusShit.Target.SyncKill(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuCategory7.AddButton("Report", "", delegate
			{
				MelonCoroutines.Start(AmongusShit.Target.targetReport(PlayerExtensions.GetVRCPlayer()));
			}, null, "#ffffff");
			reMenuCategory7.AddButton("Eject", "", delegate
			{
				AmongusShit.Target.TargetEject(PlayerExtensions.GetVRCPlayer());
			}, null, "#ffffff");
			reMenuCategory7.AddButton("Legit Vote Out", "", delegate
			{
				MelonCoroutines.Start(AmongusShit.Target.targetEveryoneVoteOut(PlayerExtensions.GetVRCPlayer()));
			}, null, "#ffffff");
			reMenuCategory7.AddButton("Obvious Vote Out", "", delegate
			{
				MelonCoroutines.Start(AmongusShit.Target.ObviousTargetOut(PlayerExtensions.GetVRCPlayer()));
			}, null, "#ffffff");
			reMenuCategory7.AddButton("Add Loop", "", delegate
			{
				VRCPlayer vrcplayer = PlayerExtensions.GetVRCPlayer();
				AmongusShit.Target.TargetLoop = true;
				MelonCoroutines.Start(AmongusShit.Target.targetLoopPlayer(vrcplayer));
			}, null, "#ffffff");
			reMenuCategory7.AddButton("<color=red>STOP LOOPS</color>", "", delegate
			{
				AmongusShit.Target.TargetLoop = false;
			}, null, "#ffffff");
		}

		// Token: 0x0400004C RID: 76
		public static Action ActionToUse = new Action(AmongusShit.Generic.Oxygen);

		// Token: 0x0400004D RID: 77
		public static Action ActionToStop = new Action(AmongusShit.Generic.Oxygen);

		// Token: 0x0400004E RID: 78
		public static Action ActionA = null;

		// Token: 0x0400004F RID: 79
		public static Action ActionB = null;

		// Token: 0x04000050 RID: 80
		private static bool loopingall = false;

		// Token: 0x04000051 RID: 81
		public static ReCategoryPage sabopage;

		// Token: 0x04000052 RID: 82
		public static ReMenuButton loopallbutton;
	}
}
