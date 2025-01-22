using System;
using System.Runtime.CompilerServices;
using Exploits;
using MelonLoader;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;
using Resources.PatchZone;
using UnityEngine;
using VRC.Udon;

namespace MenuZone
{
	// Token: 0x02000023 RID: 35
	[NullableContext(1)]
	[Nullable(0)]
	internal class TestPilotsMenu
	{
		// Token: 0x06000091 RID: 145 RVA: 0x00006AE0 File Offset: 0x00004CE0
		public static void MakeMenu(ref UiManager page)
		{
			TestPilotsMenu.TestPilots = page.QMMenu.AddCategoryPage("Sacc Test Pilots", "Sacc Flight Worlds", null, "#ffffff");
			ReMenuCategory reMenuCategory = TestPilotsMenu.TestPilots.AddCategory("Sacc");
			TestPilotsMenu.GodPilot = reMenuCategory.AddButton("<color=red> GOD MODE(WIP)", "1", delegate
			{
				Patch.TestPilotsGod = !Patch.TestPilotsGod;
				if (Patch.TestPilotsGod)
				{
					TestPilotsMenu.GodPilot.Text = "<color=green> GOD MODE";
					return;
				}
				TestPilotsMenu.GodPilot.Text = "<color=red> GOD MODE";
			}, null, "#ffffff");
			reMenuCategory.AddButton("TP 2 UFO", "Teleport To Ufo", delegate
			{
				VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = new Vector3(-9659.28f, 214.7f, 6327.62f);
			}, null, "#ffffff");
			TestPilotsMenu.ResuplyLoopPlane = reMenuCategory.AddButton("Toggle Resupply", "Teleport To Ufo", delegate
			{
				global::Exploits.TestPilots.ResupplyBool = !global::Exploits.TestPilots.ResupplyBool;
				if (global::Exploits.TestPilots.ResupplyBool)
				{
					MelonCoroutines.Start(global::Exploits.TestPilots.ResupplyLoop());
					TestPilotsMenu.ResuplyLoopPlane.Text = "Toggle Resupply";
					return;
				}
				TestPilotsMenu.ResuplyLoopPlane.Text = "<color=red>Toggle Resupply</color>";
			}, null, "#ffffff");
			reMenuCategory.AddButton("Inf All", "Teleport all to inf and destroy", delegate
			{
				MelonCoroutines.Start(global::Exploits.TestPilots.TeleportAllAndDestroy());
			}, null, "#ffffff");
			TestPilotsMenu.TeleportPilotCat = TestPilotsMenu.TestPilots.AddCategory("Teleports");
			TestPilotsMenu.TeleportPilotCat.AddButton("Join Sacc World To Load", "Join Sacc World To Load", delegate
			{
			}, null, "#ffffff");
			TestPilotsMenu.DestroyCat = TestPilotsMenu.TestPilots.AddCategory("Destroy");
			TestPilotsMenu.DestroyCat.AddButton("Join Sacc World To Load", "Join Sacc World To Load", delegate
			{
			}, null, "#ffffff");
			ReMenuPage reMenuPage = page.TargetMenu.AddMenuPage("|Test Pilots|", "", null, "#ffffff");
			reMenuPage.AddButton("INFINITY", "Bye Bitch", delegate
			{
				GameObject gameObject = global::Exploits.TestPilots.FindClosestGameObject(PlayerExtensions.GetVRCPlayer().transform.position);
				if (gameObject != null)
				{
					gameObject.transform.position = new Vector3(0f, 999800f, 0f);
					UdonBehaviour component = gameObject.GetComponent<UdonBehaviour>();
					if (component != null)
					{
						component.SendCustomEvent("PilotEnterVehicleLocal");
					}
					gameObject.transform.position = new Vector3(0f, 999800f, 0f);
				}
			}, null, "#ffffff");
			reMenuPage.AddButton("Tp2Me", "Bye Bitch", delegate
			{
				GameObject gameObject2 = global::Exploits.TestPilots.FindClosestGameObject(PlayerExtensions.GetVRCPlayer().transform.position);
				if (gameObject2 != null)
				{
					gameObject2.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 2f, 0f);
					UdonBehaviour component2 = gameObject2.GetComponent<UdonBehaviour>();
					if (component2 != null)
					{
						component2.SendCustomEvent("PilotEnterVehicleLocal");
					}
					gameObject2.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 2f, 0f);
				}
			}, null, "#ffffff");
			reMenuPage.AddButton("Destroy", "Bye Bitch", delegate
			{
				MelonCoroutines.Start(global::Exploits.TestPilots.DestroyVehicle(global::Exploits.TestPilots.FindClosestGameObject(PlayerExtensions.GetVRCPlayer().transform.position)));
			}, null, "#ffffff");
		}

		// Token: 0x0400008F RID: 143
		public static ReMenuCategory TeleportPilotCat;

		// Token: 0x04000090 RID: 144
		public static ReMenuCategory DestroyCat;

		// Token: 0x04000091 RID: 145
		public static ReCategoryPage TestPilots;

		// Token: 0x04000092 RID: 146
		public static ReMenuButton GodPilot;

		// Token: 0x04000093 RID: 147
		public static ReMenuButton ResuplyLoopPlane;
	}
}
