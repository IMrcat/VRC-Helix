using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using VRC.Udon;

namespace Values
{
	// Token: 0x02000005 RID: 5
	[NullableContext(1)]
	[Nullable(0)]
	internal class GatherUdon
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002090 File Offset: 0x00000290
		public static void UdonGather()
		{
			GatherUdon.udonObjects = null;
			ManualResetEvent udonGatherEvent = GatherUdon.UdonGatherEvent;
			lock (udonGatherEvent)
			{
				GatherUdon.udonObjects = Resources.FindObjectsOfTypeAll<UdonBehaviour>();
				GatherUdon.UdonGatherEvent.Set();
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020EC File Offset: 0x000002EC
		public static UdonBehaviour[] GetUdonObjects()
		{
			ManualResetEvent udonGatherEvent = GatherUdon.UdonGatherEvent;
			UdonBehaviour[] array;
			lock (udonGatherEvent)
			{
				GatherUdon.UdonGatherEvent.WaitOne();
				array = GatherUdon.udonObjects;
			}
			return array;
		}

		// Token: 0x04000003 RID: 3
		public static ManualResetEvent UdonGatherEvent = new ManualResetEvent(false);

		// Token: 0x04000004 RID: 4
		private static UdonBehaviour[] udonObjects;

		// Token: 0x04000005 RID: 5
		private static Dictionary<UdonBehaviour, List<string>> udonBehaviourEntries = new Dictionary<UdonBehaviour, List<string>>();
	}
}
