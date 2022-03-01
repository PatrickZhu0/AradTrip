using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class Status
	{
		// Token: 0x0400001E RID: 30
		public TaskStatus eStatus;

		// Token: 0x0400001F RID: 31
		public GameObject[] targets;
	}
}
