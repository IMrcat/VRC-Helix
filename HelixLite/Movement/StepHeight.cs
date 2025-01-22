using System;
using Resources;
using VRC;

namespace Movement
{
	// Token: 0x02000017 RID: 23
	internal class StepHeight
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00004568 File Offset: 0x00002768
		public static void SetStepheight()
		{
			if (ConfigZone.AutoStep.Value)
			{
				if (!StepHeight.flag)
				{
					StepHeight.origionalheight = Player.Method_Internal_Static_get_Player_0().gameObject.GetComponent<VRCPlayerStepHeight>().maxStepHeight;
					StepHeight.flag = true;
				}
				Player.Method_Internal_Static_get_Player_0().gameObject.GetComponent<VRCPlayerStepHeight>().maxStepHeight = 111f;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000045C0 File Offset: 0x000027C0
		public static void SetIfWasSet()
		{
			if (ConfigZone.AutoStep.Value)
			{
				if (StepHeight.flag)
				{
					Player.Method_Internal_Static_get_Player_0().gameObject.GetComponent<VRCPlayerStepHeight>().maxStepHeight = 111f;
					return;
				}
				StepHeight.origionalheight = Player.Method_Internal_Static_get_Player_0().gameObject.GetComponent<VRCPlayerStepHeight>().maxStepHeight;
				StepHeight.flag = true;
				Player.Method_Internal_Static_get_Player_0().gameObject.GetComponent<VRCPlayerStepHeight>().maxStepHeight = 111f;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00004632 File Offset: 0x00002832
		public static void ResetStepHeight()
		{
			if (!ConfigZone.AutoStep.Value && !StepHeight.flag)
			{
				Player.Method_Internal_Static_get_Player_0().gameObject.GetComponent<VRCPlayerStepHeight>().maxStepHeight = StepHeight.origionalheight;
				StepHeight.origionalheight = float.NaN;
				StepHeight.flag = false;
			}
		}

		// Token: 0x0400004A RID: 74
		public static bool flag = false;

		// Token: 0x0400004B RID: 75
		private static float origionalheight = float.NaN;
	}
}
