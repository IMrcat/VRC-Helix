using System;
using Resources;
using UnityEngine;
using VRC.SDKBase;

namespace Movement
{
	// Token: 0x02000013 RID: 19
	internal class Jetpack
	{
		// Token: 0x06000064 RID: 100 RVA: 0x000043E0 File Offset: 0x000025E0
		public static void Update()
		{
			if (Jetpack.Jetpackbool && (Binds.Button_Jump.GetState(0) || Input.GetKey(32)))
			{
				Vector3 velocity = Networking.LocalPlayer.GetVelocity();
				velocity.y = Networking.LocalPlayer.GetJumpImpulse();
				Networking.LocalPlayer.SetVelocity(velocity);
			}
		}

		// Token: 0x04000049 RID: 73
		public static bool Jetpackbool;
	}
}
