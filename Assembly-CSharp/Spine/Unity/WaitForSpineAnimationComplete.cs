using System;
using System.Collections;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A20 RID: 18976
	public class WaitForSpineAnimationComplete : IEnumerator
	{
		// Token: 0x0601B66F RID: 112239 RVA: 0x00873AC6 File Offset: 0x00871EC6
		public WaitForSpineAnimationComplete(TrackEntry trackEntry)
		{
			this.SafeSubscribe(trackEntry);
		}

		// Token: 0x0601B670 RID: 112240 RVA: 0x00873AD5 File Offset: 0x00871ED5
		private void HandleComplete(TrackEntry trackEntry)
		{
			this.m_WasFired = true;
		}

		// Token: 0x0601B671 RID: 112241 RVA: 0x00873ADE File Offset: 0x00871EDE
		private void SafeSubscribe(TrackEntry trackEntry)
		{
			if (trackEntry == null)
			{
				Debug.LogWarning("TrackEntry was null. Coroutine will continue immediately.");
				this.m_WasFired = true;
			}
			else
			{
				trackEntry.Complete += this.HandleComplete;
			}
		}

		// Token: 0x0601B672 RID: 112242 RVA: 0x00873B0E File Offset: 0x00871F0E
		public WaitForSpineAnimationComplete NowWaitFor(TrackEntry trackEntry)
		{
			this.SafeSubscribe(trackEntry);
			return this;
		}

		// Token: 0x0601B673 RID: 112243 RVA: 0x00873B18 File Offset: 0x00871F18
		bool IEnumerator.MoveNext()
		{
			if (this.m_WasFired)
			{
				((IEnumerator)this).Reset();
				return false;
			}
			return true;
		}

		// Token: 0x0601B674 RID: 112244 RVA: 0x00873B2E File Offset: 0x00871F2E
		void IEnumerator.Reset()
		{
			this.m_WasFired = false;
		}

		// Token: 0x17002455 RID: 9301
		// (get) Token: 0x0601B675 RID: 112245 RVA: 0x00873B37 File Offset: 0x00871F37
		object IEnumerator.Current
		{
			get
			{
				return null;
			}
		}

		// Token: 0x04013166 RID: 78182
		private bool m_WasFired;
	}
}
