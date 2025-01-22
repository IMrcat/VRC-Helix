using System;
using System.Collections;
using System.Runtime.CompilerServices;
using MelonLoader;
using UnityEngine;

namespace EdenRaycastExtension
{
	// Token: 0x0200000A RID: 10
	[NullableContext(1)]
	[Nullable(0)]
	internal class RayCastView
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002734 File Offset: 0x00000934
		public static RaycastHit Cast(Vector3 origin, Vector3 direction, float maxDistance, Color HitColor = default(Color), Color MissColor = default(Color), float Thickness = 0.03f, float duration = 1f, LayerMask LayerMask = default(LayerMask))
		{
			if (RayCastView.Cube == null)
			{
				RayCastView.Cube = GameObject.CreatePrimitive(3);
				Collider component = RayCastView.Cube.GetComponent<Collider>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else if (!RayCastView.Cube.active)
			{
				RayCastView.Cube.SetActive(true);
			}
			LayerMask layerMask = default(LayerMask);
			if (LayerMask == default(LayerMask))
			{
				int num = 13;
				int num2 = 9;
				int num3 = 11;
				int num4 = (1 << num) | 1 | (1 << num2) | (1 << num3);
				LayerMask layerMask2 = default(LayerMask);
				layerMask2.value = num4;
				layerMask = layerMask2;
			}
			else
			{
				layerMask = LayerMask;
			}
			RayCastView.hideDelay = duration;
			RayCastView.lastRaycastTime = Time.time;
			if (HitColor == default(Color))
			{
				HitColor = Color.red;
			}
			if (MissColor == default(Color))
			{
				MissColor = Color.white;
			}
			Ray ray;
			ray..ctor(origin, direction);
			RaycastHit raycastHit;
			bool flag = Physics.Raycast(ray, ref raycastHit, maxDistance, layerMask);
			Renderer component2 = RayCastView.Cube.GetComponent<Renderer>();
			if (component2 != null)
			{
				component2.material.color = (flag ? HitColor : MissColor);
			}
			RayCastView.Cube.transform.position = ray.GetPoint(flag ? (raycastHit.distance / 2f) : (maxDistance / 2f));
			RayCastView.Cube.transform.forward = direction;
			RayCastView.Cube.transform.localScale = new Vector3(Thickness, Thickness, flag ? raycastHit.distance : maxDistance);
			if (!RayCastView.isHidingCoroutineRunning || Time.time < RayCastView.lastRaycastTime + (RayCastView.hideDelay + 0.5f))
			{
				RayCastView.isHidingCoroutineRunning = true;
				MelonCoroutines.Start(RayCastView.HideCubeAfterDelay());
			}
			if (!flag)
			{
				return default(RaycastHit);
			}
			return raycastHit;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000291A File Offset: 0x00000B1A
		private static IEnumerator HideCubeAfterDelay()
		{
			while (Time.time < RayCastView.lastRaycastTime + RayCastView.hideDelay)
			{
				yield return null;
			}
			if (RayCastView.Cube != null)
			{
				RayCastView.Cube.SetActive(false);
			}
			RayCastView.isHidingCoroutineRunning = false;
			yield break;
		}

		// Token: 0x0400000F RID: 15
		private static GameObject Cube = null;

		// Token: 0x04000010 RID: 16
		private static float lastRaycastTime = -1f;

		// Token: 0x04000011 RID: 17
		private static bool isHidingCoroutineRunning = false;

		// Token: 0x04000012 RID: 18
		private static float hideDelay = 1f;
	}
}
