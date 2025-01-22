using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Exploits;
using HelixLiteModule;
using MelonLoader;
using Resources;
using UnityEngine;
using Values;
using VRC;
using VRC.SDKBase;

namespace Movement
{
	// Token: 0x02000012 RID: 18
	[NullableContext(1)]
	[Nullable(0)]
	internal class Flight
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00003E08 File Offset: 0x00002008
		private static Transform GetCameraTransform()
		{
			return VRCPlayer.field_Internal_Static_VRCPlayer_0.transform;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003E14 File Offset: 0x00002014
		internal static void ToggleCollidersOnPlayer(bool toggle)
		{
			VRCPlayer field_Internal_Static_VRCPlayer_ = VRCPlayer.field_Internal_Static_VRCPlayer_0;
			if (field_Internal_Static_VRCPlayer_ != null)
			{
				foreach (Collider collider in Flight.FindAllComponentsInGameObject<Collider>(field_Internal_Static_VRCPlayer_.gameObject, true))
				{
					collider.enabled = toggle;
				}
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003E7C File Offset: 0x0000207C
		public static void FlyUpdate()
		{
			if (Main.LoadedIntoWorld && !TestPilots.JoinedSacc)
			{
				VRCPlayer field_Internal_Static_VRCPlayer_ = VRCPlayer.field_Internal_Static_VRCPlayer_0;
				VRCPlayerApi vrcplayerApi = ((field_Internal_Static_VRCPlayer_ != null) ? field_Internal_Static_VRCPlayer_.field_Private_VRCPlayerApi_0 : null);
				if (vrcplayerApi == null)
				{
					return;
				}
				if (Flight.VelocityFly && !vrcplayerApi.IsPlayerGrounded())
				{
					float fixedDeltaTime = Time.fixedDeltaTime;
					float num = Mathf.Max(Binds.Trigger.GetAxis(2), Input.GetKey(102) > false);
					float num2 = Mathf.Max(Binds.Trigger.GetAxis(1), Input.GetKey(32) > false);
					Vector3 velocity = vrcplayerApi.GetVelocity();
					Vector3 vector = vrcplayerApi.GetTrackingData(vrcplayerApi.IsUserInVR() ? 2 : 0).rotation * Vector3.forward;
					float num3 = -(Vector3.Dot(velocity, vector) * Flight.Back_Thrust_Strength * fixedDeltaTime);
					Vector3 vector2 = vector * Flight.Thrust_Strength * num * fixedDeltaTime * Mathf.Max(1f, num3 * num);
					Vector3 vector3 = Vector3.up * Flight.Thrust_Strength * num2 * fixedDeltaTime;
					vrcplayerApi.SetVelocity(velocity + vector2 + vector3);
				}
				Player player = Player.Method_Internal_Static_get_Player_0();
				if (player != null)
				{
					if (ConfigZone.QFlyBool.Value && (Binds.Doubletap(Binds.Button_Jump, false) || Binds.Doubletap(32)))
					{
						Flight.flytoggle = !Flight.flytoggle;
						Flight.ToggleCollidersOnPlayer(Flight.flytoggle);
						MelonLogger.Msg("Toggles Flight: " + Flight.flytoggle.ToString());
					}
					if (!Flight.flytoggle && !Flight.flagforgrav)
					{
						player.gameObject.GetComponent<CharacterController>().enabled = !Flight.flytoggle;
						Flight.flagforgrav = true;
						Physics.gravity = LocalUser.OrigionalGravity;
					}
					else if (Flight.flytoggle && Physics.gravity != Vector3.zero)
					{
						player.gameObject.GetComponent<CharacterController>().enabled = !Flight.flytoggle;
						Flight.flagforgrav = false;
						LocalUser.OrigionalGravity = Physics.gravity;
						Physics.gravity = Vector3.zero;
						return;
					}
					if (Flight.flytoggle)
					{
						float num4 = Time.deltaTime * (Input.GetKey(304) ? 15f : 10f) * (Flight.FlightMultiplyer / 10f);
						Transform transform = player.transform;
						Transform cameraTransform = Flight.GetCameraTransform();
						if (vrcplayerApi.IsUserInVR())
						{
							Flight.UpdateVRFlight(transform, cameraTransform, num4);
							return;
						}
						Flight.UpdateDesktopFlight(transform, cameraTransform, num4);
					}
				}
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000040F0 File Offset: 0x000022F0
		private static void UpdateVRFlight(Transform playerTransform, Transform cameraTransform, float speedMultiplier)
		{
			if (Binds.RotateJoystick.GetAxis(2).y < -0.5f)
			{
				playerTransform.position -= cameraTransform.up * speedMultiplier;
			}
			if (Binds.RotateJoystick.GetAxis(2).y > 0.5f)
			{
				playerTransform.position += cameraTransform.up * speedMultiplier;
			}
			if (Binds.MoveJoystick.GetAxis(1).y != 0f)
			{
				playerTransform.position += cameraTransform.forward * (speedMultiplier * Binds.MoveJoystick.GetAxis(1).y);
			}
			if (Binds.MoveJoystick.GetAxis(1).x != 0f)
			{
				playerTransform.position += cameraTransform.right * (speedMultiplier * Binds.MoveJoystick.GetAxis(1).x);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000041F0 File Offset: 0x000023F0
		private static void UpdateDesktopFlight(Transform playerTransform, Transform cameraTransform, float speedMultiplier)
		{
			speedMultiplier *= 87f;
			if (Input.GetKey(119))
			{
				playerTransform.position += cameraTransform.forward * speedMultiplier * Time.deltaTime;
			}
			if (Input.GetKey(115))
			{
				playerTransform.position -= cameraTransform.forward * speedMultiplier * Time.deltaTime;
			}
			if (Input.GetKey(97))
			{
				playerTransform.position -= cameraTransform.right * speedMultiplier * Time.deltaTime;
			}
			if (Input.GetKey(100))
			{
				playerTransform.position += cameraTransform.right * speedMultiplier * Time.deltaTime;
			}
			if (Input.GetKey(113))
			{
				playerTransform.position -= cameraTransform.up * speedMultiplier * Time.deltaTime;
			}
			if (Input.GetKey(101))
			{
				playerTransform.position += cameraTransform.up * speedMultiplier * Time.deltaTime;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004328 File Offset: 0x00002528
		internal static List<T> FindAllComponentsInGameObject<T>(GameObject gameObject, bool includeInactive = true) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				return list;
			}
			try
			{
				list.AddRange(gameObject.GetComponents<T>());
				list.AddRange(gameObject.GetComponentsInParent<T>(includeInactive));
				list.AddRange(gameObject.GetComponentsInChildren<T>(includeInactive));
			}
			catch (Exception ex)
			{
				MelonLogger.Msg("Error FindAllComponentsInGameObject ", new object[] { ex, " FindAllComponentsInGameObject" });
			}
			return list;
		}

		// Token: 0x04000042 RID: 66
		public static bool flytoggle;

		// Token: 0x04000043 RID: 67
		private static Dictionary<KeyCode, float> lastTime = new Dictionary<KeyCode, float>();

		// Token: 0x04000044 RID: 68
		private static bool flagforgrav = false;

		// Token: 0x04000045 RID: 69
		public static float FlightMultiplyer = 10f;

		// Token: 0x04000046 RID: 70
		public static float Thrust_Strength = 16f;

		// Token: 0x04000047 RID: 71
		public static float Back_Thrust_Strength = 31f;

		// Token: 0x04000048 RID: 72
		public static bool VelocityFly = false;
	}
}
