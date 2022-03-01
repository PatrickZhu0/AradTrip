using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020017E9 RID: 6121
	public class ComTimeTick : MonoBehaviour
	{
		// Token: 0x0600F0FC RID: 61692 RVA: 0x0040E410 File Offset: 0x0040C810
		public void SetEndTime(uint stamp)
		{
			this.stamp = stamp;
		}

		// Token: 0x0600F0FD RID: 61693 RVA: 0x0040E419 File Offset: 0x0040C819
		private void Start()
		{
		}

		// Token: 0x0600F0FE RID: 61694 RVA: 0x0040E41C File Offset: 0x0040C81C
		private void Update()
		{
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			uint num = (serverTime < this.stamp) ? (this.stamp - serverTime) : 0U;
			if (this.onTick != null)
			{
				this.onTick.Invoke(num);
			}
		}

		// Token: 0x04009413 RID: 37907
		public UnityAction<uint> onTick;

		// Token: 0x04009414 RID: 37908
		private uint stamp;
	}
}
