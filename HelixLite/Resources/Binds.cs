using System;
using System.Runtime.CompilerServices;
using MelonLoader;
using UnityEngine;
using Valve.VR;

namespace Resources
{
	// Token: 0x0200000C RID: 12
	[NullableContext(1)]
	[Nullable(0)]
	internal class Binds
	{
		// Token: 0x06000024 RID: 36 RVA: 0x000029EC File Offset: 0x00000BEC
		public static void Register()
		{
			Binds.Button_Jump = SteamVR_Input.GetBooleanAction("jump", false);
			Binds.Button_Mic = SteamVR_Input.GetBooleanAction("Toggle Microphone", false);
			Binds.Button_QM = SteamVR_Input.GetBooleanAction("Menu", false);
			Binds.Button_Grab = SteamVR_Input.GetBooleanAction("Grab", false);
			Binds.Button_Interact = SteamVR_Input.GetBooleanAction("Interact", false);
			Binds.Trigger = SteamVR_Input.GetSingleAction("gesture_trigger_axis", false);
			Binds.MoveJoystick = SteamVR_Input.GetVector2Action("Move", false);
			Binds.RotateJoystick = SteamVR_Input.GetVector2Action("Rotate", false);
			MelonLogger.Msg("Binds Registered!");
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002A84 File Offset: 0x00000C84
		public static bool Doubletap(KeyCode key)
		{
			if (Input.GetKeyDown(key))
			{
				float time = Time.time;
				float num = time - Binds.lastTapTime;
				if (Mathf.Abs(num) < 0.35f && Mathf.Abs(num) > 0.03f)
				{
					Binds.lastTapTime = time;
					return true;
				}
				Binds.lastTapTime = time;
			}
			return false;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002AD0 File Offset: 0x00000CD0
		public static bool Doubletap(SteamVR_Action_Boolean key, bool lefthand = false)
		{
			SteamVR_Input_Sources steamVR_Input_Sources = (lefthand ? 1 : 2);
			if (key.GetState(steamVR_Input_Sources))
			{
				float time = Time.time;
				float num = time - Binds.lastTapTime;
				if (Mathf.Abs(num) < 0.35f && Mathf.Abs(num) > 0.03f)
				{
					Binds.lastTapTime = time;
					return true;
				}
				Binds.lastTapTime = time;
			}
			return false;
		}

		// Token: 0x04000013 RID: 19
		public static SteamVR_Action_Boolean Button_Jump;

		// Token: 0x04000014 RID: 20
		public static SteamVR_Action_Boolean Button_QM;

		// Token: 0x04000015 RID: 21
		public static SteamVR_Action_Boolean Button_Mic;

		// Token: 0x04000016 RID: 22
		public static SteamVR_Action_Boolean Button_Grab;

		// Token: 0x04000017 RID: 23
		public static SteamVR_Action_Boolean Button_Interact;

		// Token: 0x04000018 RID: 24
		public static SteamVR_Action_Single Trigger;

		// Token: 0x04000019 RID: 25
		public static SteamVR_Action_Vector2 MoveJoystick;

		// Token: 0x0400001A RID: 26
		public static SteamVR_Action_Vector2 RotateJoystick;

		// Token: 0x0400001B RID: 27
		public const float doubleTapTimeThreshold = 0.35f;

		// Token: 0x0400001C RID: 28
		public const float otherThreshold = 0.03f;

		// Token: 0x0400001D RID: 29
		public static float lastTapTime = -10f;
	}
}
