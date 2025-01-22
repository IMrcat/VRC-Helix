using System;
using Resources;
using Values;

namespace Movement
{
	// Token: 0x02000014 RID: 20
	internal class RunJump
	{
		// Token: 0x06000066 RID: 102 RVA: 0x0000443C File Offset: 0x0000263C
		public static void SetMovementValue(float value)
		{
			ConfigZone.MovementSpeed.Value = value;
			if (ConfigZone.ForceMovementSpeedBool.Value)
			{
				RunJump.ApplyMovementSpeed(ConfigZone.MovementSpeed.Value, -1f, -1f);
				return;
			}
			RunJump.ApplyMovementSpeed(LocalUser.OrigionalWalkSpeed, LocalUser.OrigionalStrafeSpeed, LocalUser.OrigionalRunSpeed);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004490 File Offset: 0x00002690
		public static void ApplyMovementSpeed(float Walk, float Strafe = -1f, float Run = -1f)
		{
			if (Run >= 0f && Strafe >= 0f)
			{
				VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.SetRunSpeed(Run);
				VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.SetWalkSpeed(Walk);
				VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.SetStrafeSpeed(Strafe);
				return;
			}
			VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.SetRunSpeed(Walk * 2f);
			VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.SetWalkSpeed(Walk);
			VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.SetStrafeSpeed(Walk);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004514 File Offset: 0x00002714
		public static void SetJumpHeightValue(float value)
		{
			ConfigZone.JumpHeight.Value = value;
			if (ConfigZone.ForceJumpBool.Value)
			{
				RunJump.ApplyJumpHeight(ConfigZone.JumpHeight.Value);
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000453C File Offset: 0x0000273C
		public static void ApplyJumpHeight(float value)
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.SetJumpImpulse(value);
		}
	}
}
