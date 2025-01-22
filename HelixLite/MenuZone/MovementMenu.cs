using System;
using System.Runtime.CompilerServices;
using MelonLoader;
using Movement;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using Resources;
using UnityEngine;
using Values;

namespace MenuZone
{
	// Token: 0x0200001E RID: 30
	[NullableContext(1)]
	[Nullable(0)]
	internal class MovementMenu
	{
		// Token: 0x06000081 RID: 129 RVA: 0x000058A0 File Offset: 0x00003AA0
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			MovementMenu.MovementPage = Manager.QMMenu.AddCategoryPage("l Movement l", "", MenuIcon, "#ffffff");
			ReMenuCategory reMenuCategory = MovementMenu.MovementPage.AddCategory("Movement Toggles");
			MovementMenu.QFly = reMenuCategory.AddButton("<color=green>~DoubleTap~", "Double tap jump to fly", delegate
			{
				ConfigZone.QFlyBool.Value = !ConfigZone.QFlyBool.Value;
				if (ConfigZone.QFlyBool.Value)
				{
					MovementMenu.QFly.Text = "<color=green>~DoubleTap~";
					return;
				}
				MovementMenu.QFly.Text = "<color=red>~DoubleTap~";
			}, ButtonIcon, "#ffffff");
			MovementMenu.FlyToggle = reMenuCategory.AddButton("<color=red>~Flight~", "Toggle Flight", delegate
			{
				Flight.flytoggle = !Flight.flytoggle;
				if (Flight.flytoggle)
				{
					MovementMenu.FlyToggle.Text = "<color=green>~Flight~";
					return;
				}
				MovementMenu.FlyToggle.Text = "<color=red>~Flight~";
			}, ButtonIcon, "#ffffff");
			MovementMenu.Jetpack = reMenuCategory.AddButton("<color=red>~JetPack~", "Toggle Jetpack", delegate
			{
				global::Movement.Jetpack.Jetpackbool = !global::Movement.Jetpack.Jetpackbool;
				if (global::Movement.Jetpack.Jetpackbool)
				{
					MovementMenu.Jetpack.Text = "<color=green>~JetPack~</color>";
					return;
				}
				MovementMenu.Jetpack.Text = "<color=red>~JetPack~</color>";
			}, ButtonIcon, "#ffffff");
			MovementMenu.VelocityFly = reMenuCategory.AddButton("<color=red>~Velocity Flight~", "Space+F OR Left and Right Joystick Flight!", delegate
			{
				Flight.VelocityFly = !Flight.VelocityFly;
				if (Flight.VelocityFly)
				{
					MovementMenu.VelocityFly.Text = "<color=green>~Velocity~";
					if (ConfigZone.QFlyBool.Value)
					{
						MovementMenu.WasQFLYOnBeforeVelocity = true;
						ConfigZone.QFlyBool.Value = false;
					}
				}
				else
				{
					if (MovementMenu.WasQFLYOnBeforeVelocity)
					{
						MovementMenu.WasQFLYOnBeforeVelocity = false;
						ConfigZone.QFlyBool.Value = true;
					}
					MovementMenu.VelocityFly.Text = "<color=red>~Velocity~";
				}
				MelonLogger.Msg(Flight.VelocityFly);
			}, ButtonIcon, "#ffffff");
			MovementMenu.ToggleSpeed = reMenuCategory.AddButton("<color=red>~Movement Speed~", "Toggle AutoStep", delegate
			{
				ConfigZone.ForceMovementSpeedBool.Value = !ConfigZone.ForceMovementSpeedBool.Value;
				if (ConfigZone.ForceMovementSpeedBool.Value)
				{
					MovementMenu.ToggleSpeed.Text = "<color=green>~Movement Speed~</color>";
					RunJump.ApplyMovementSpeed(ConfigZone.MovementSpeed.Value, -1f, -1f);
					return;
				}
				MovementMenu.ToggleSpeed.Text = "<color=red>~Movement Speed~</color>";
				RunJump.ApplyMovementSpeed(LocalUser.OrigionalWalkSpeed, LocalUser.OrigionalStrafeSpeed, LocalUser.OrigionalRunSpeed);
			}, ButtonIcon, "#ffffff");
			MovementMenu.ToggleJump = reMenuCategory.AddButton("<color=red>~Force Jump~", "Toggle AutoStep", delegate
			{
				ConfigZone.ForceJumpBool.Value = !ConfigZone.ForceJumpBool.Value;
				if (ConfigZone.ForceJumpBool.Value)
				{
					MovementMenu.ToggleJump.Text = "<color=green>~Force Jump~</color>";
					RunJump.ApplyJumpHeight(ConfigZone.JumpHeight.Value);
					return;
				}
				MovementMenu.ToggleJump.Text = "<color=red>~Force Jump~</color>";
				RunJump.ApplyJumpHeight(LocalUser.OrigionalJumpheight);
			}, ButtonIcon, "#ffffff");
			MovementMenu.AutoStep = reMenuCategory.AddButton("<color=red>~Auto-Step~", "Toggle AutoStep", delegate
			{
				ConfigZone.AutoStep.Value = !ConfigZone.AutoStep.Value;
				if (ConfigZone.AutoStep.Value)
				{
					MovementMenu.AutoStep.Text = "<color=green>~Auto-Step~</color>";
					StepHeight.SetStepheight();
					return;
				}
				MovementMenu.AutoStep.Text = "<color=red>~Auto-Step~</color>";
				StepHeight.ResetStepHeight();
			}, ButtonIcon, "#ffffff");
			MovementMenu.SliderTest = MovementMenu.MovementPage.AddSliderCategory("Settings");
			MovementMenu.SliderTest.AddSlider("Flight Speed", "", delegate(float value)
			{
				Flight.FlightMultiplyer = value;
			}, 5f, 3f, 40f, "#ffffff");
			MovementMenu.SliderTest.AddSlider("Back Thrust", "", delegate(float value)
			{
				Flight.Back_Thrust_Strength = value;
			}, 45f, 0f, 60f, "#ffffff");
			MovementMenu.SliderTest.AddSlider("Thrust strength", "", delegate(float value)
			{
				Flight.Thrust_Strength = value;
			}, 29.7f, 0f, 60f, "#ffffff");
			MovementMenu.SliderTest.AddSlider("Movement Speed", "Default 5", delegate(float value)
			{
				RunJump.SetMovementValue(value);
			}, 5f, 0f, 15f, "#ffffff");
			MovementMenu.SliderTest.AddSlider("Jump Height", "Default 3", delegate(float value)
			{
				RunJump.SetJumpHeightValue(value);
			}, 3f, 0f, 15f, "#ffffff");
		}

		// Token: 0x04000070 RID: 112
		public static ReCategoryPage MovementPage;

		// Token: 0x04000071 RID: 113
		public static ReMenuButton AutoStep;

		// Token: 0x04000072 RID: 114
		public static ReMenuButton QFly;

		// Token: 0x04000073 RID: 115
		public static ReMenuButton FlyToggle;

		// Token: 0x04000074 RID: 116
		public static ReMenuButton ToggleSpeed;

		// Token: 0x04000075 RID: 117
		public static ReMenuButton ToggleJump;

		// Token: 0x04000076 RID: 118
		public static ReMenuButton Jetpack;

		// Token: 0x04000077 RID: 119
		public static ReMenuButton VelocityFly;

		// Token: 0x04000078 RID: 120
		public static ReMenuSliderCategory SliderTest;

		// Token: 0x04000079 RID: 121
		private static bool WasQFLYOnBeforeVelocity;
	}
}
