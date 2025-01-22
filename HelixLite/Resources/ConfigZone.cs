using System;
using System.Runtime.CompilerServices;
using MelonLoader;

namespace Resources
{
	// Token: 0x0200000D RID: 13
	[NullableContext(1)]
	[Nullable(0)]
	internal class ConfigZone
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002B3C File Offset: 0x00000D3C
		public static void OnStart()
		{
			ConfigZone.HelixCatagory = MelonPreferences.CreateCategory("HelixLite");
			ConfigZone.ESPBool = ConfigZone.HelixCatagory.CreateEntry<bool>("ESP", false, null, null, false, false, null, null);
			ConfigZone.NeonESPBool = ConfigZone.HelixCatagory.CreateEntry<bool>("NeonESP", false, null, null, false, false, null, null);
			ConfigZone.NamePlateBool = ConfigZone.HelixCatagory.CreateEntry<bool>("NamePlates", false, null, null, false, false, null, null);
			ConfigZone.QFlyBool = ConfigZone.HelixCatagory.CreateEntry<bool>("QFly/DoubleTap", true, null, null, false, false, null, null);
			ConfigZone.ForceMovementSpeedBool = ConfigZone.HelixCatagory.CreateEntry<bool>("Force movement Speed", false, null, "When enabled, will override the worlds walk and run speeds with the movement speed", false, false, null, null);
			ConfigZone.MovementSpeed = ConfigZone.HelixCatagory.CreateEntry<float>("Movement Speed", 2f, null, null, false, false, null, null);
			ConfigZone.ForceJumpBool = ConfigZone.HelixCatagory.CreateEntry<bool>("Force Jump", false, null, "When enabled, will override the worlds Jump Height (Useful for worlds like murder where its off by default)", false, false, null, null);
			ConfigZone.JumpHeight = ConfigZone.HelixCatagory.CreateEntry<float>("Jump Height", 2f, null, null, false, false, null, null);
			ConfigZone.AutoStep = ConfigZone.HelixCatagory.CreateEntry<bool>("Auto Step", false, null, "When enabled will allow you to walk upto objects like tables or short walls and it will automatically climb you tot he top of the object line minecraft auto step", false, false, null, null);
			ConfigZone.SpoofName = ConfigZone.HelixCatagory.CreateEntry<bool>("SpoofName", true, null, null, false, false, null, null);
			ConfigZone.World1 = ConfigZone.HelixCatagory.CreateEntry<string>("World 1", "BlackCat | wrld_4cf554b4-430c-4f8f-b53e-1f294eed230b | 13", null, "Replace with World Name and Worldid (world name is used for the button in the random instance joiner) then number is the minumum players to join. !!!!THIS APPLIES TO ALL THE WORLDS 1 THROUGH 8 BELLOW!!!!", false, false, null, null);
			ConfigZone.World2 = ConfigZone.HelixCatagory.CreateEntry<string>("World 2", "Murder4 | wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe | 7", null, null, false, false, null, null);
			ConfigZone.World3 = ConfigZone.HelixCatagory.CreateEntry<string>("World 3", "Amongus | wrld_dd036610-a246-4f52-bf01-9d7cea3405d7 | 6", null, null, false, false, null, null);
			ConfigZone.World4 = ConfigZone.HelixCatagory.CreateEntry<string>("World 4", "Prison Escape | wrld_14750dd6-26a1-4edb-ae67-cac5bcd9ed6a | 7", null, null, false, false, null, null);
			ConfigZone.World5 = ConfigZone.HelixCatagory.CreateEntry<string>("World 5", "Just B Club 3 | wrld_e6569266-21cd-4275-8aef-47fcb7458931 | 13", null, null, false, false, null, null);
			ConfigZone.World6 = ConfigZone.HelixCatagory.CreateEntry<string>("World 6", "Test Pilots | wrld_e4908cea-023b-4749-9ad7-a898b12996e7 | 6", null, null, false, false, null, null);
			ConfigZone.World7 = ConfigZone.HelixCatagory.CreateEntry<string>("World 7", "Optimized Box | wrld_1a8b8684-3b19-4770-a4a7-288762f57b29 | 10", null, null, false, false, null, null);
			ConfigZone.World8 = ConfigZone.HelixCatagory.CreateEntry<string>("World 8 ", "Popcorn Palace | wrld_266523e8-9161-40da-acd0-6bd82e075833 | 15", null, null, false, false, null, null);
			ConfigZone.PublicAndGroups = ConfigZone.HelixCatagory.CreateEntry<bool>("Join Publics & Groups?", true, null, "When using the launchpad join random instances it will decide if it should include groups (true) or not (false)", false, false, null, null);
			ConfigZone.E1Payload = ConfigZone.HelixCatagory.CreateEntry<string>("Base64 E1 payload for earrape: ", "AQAAAOxnk8cADjsA +H3owCVgPq4w5B67lcSx14zff9FCPAAgS0VNT05PLlBFVCBYIElOVkFMSUQuR0cgICAgICnAJWA+rjA=", null, null, false, false, null, null);
		}

		// Token: 0x0400001E RID: 30
		private static MelonPreferences_Category HelixCatagory;

		// Token: 0x0400001F RID: 31
		public static MelonPreferences_Entry<bool> ESPBool;

		// Token: 0x04000020 RID: 32
		public static MelonPreferences_Entry<bool> NeonESPBool;

		// Token: 0x04000021 RID: 33
		public static MelonPreferences_Entry<bool> NamePlateBool;

		// Token: 0x04000022 RID: 34
		public static MelonPreferences_Entry<bool> QFlyBool;

		// Token: 0x04000023 RID: 35
		public static MelonPreferences_Entry<bool> ForceJumpBool;

		// Token: 0x04000024 RID: 36
		public static MelonPreferences_Entry<bool> ForceMovementSpeedBool;

		// Token: 0x04000025 RID: 37
		public static MelonPreferences_Entry<bool> AutoStep;

		// Token: 0x04000026 RID: 38
		public static MelonPreferences_Entry<bool> PublicAndGroups;

		// Token: 0x04000027 RID: 39
		public static MelonPreferences_Entry<bool> SpoofName;

		// Token: 0x04000028 RID: 40
		public static MelonPreferences_Entry<float> MovementSpeed;

		// Token: 0x04000029 RID: 41
		public static MelonPreferences_Entry<float> JumpHeight;

		// Token: 0x0400002A RID: 42
		public static MelonPreferences_Entry<string> World1;

		// Token: 0x0400002B RID: 43
		public static MelonPreferences_Entry<string> World2;

		// Token: 0x0400002C RID: 44
		public static MelonPreferences_Entry<string> World3;

		// Token: 0x0400002D RID: 45
		public static MelonPreferences_Entry<string> World4;

		// Token: 0x0400002E RID: 46
		public static MelonPreferences_Entry<string> World5;

		// Token: 0x0400002F RID: 47
		public static MelonPreferences_Entry<string> World6;

		// Token: 0x04000030 RID: 48
		public static MelonPreferences_Entry<string> World7;

		// Token: 0x04000031 RID: 49
		public static MelonPreferences_Entry<string> World8;

		// Token: 0x04000032 RID: 50
		public static MelonPreferences_Entry<string> E1Payload;
	}
}
