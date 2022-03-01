using System;
using System.Collections;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A22 RID: 18978
	public class WaitForSpineTrackEntryEnd : IEnumerator
	{
		// Token: 0x0601B686 RID: 112262 RVA: 0x00873D98 File Offset: 0x00872198
		public WaitForSpineTrackEntryEnd(TrackEntry trackEntry)
		{
			this.SafeSubscribe(trackEntry);
		}

		// Token: 0x0601B687 RID: 112263 RVA: 0x00873DA7 File Offset: 0x008721A7
		private void HandleEnd(TrackEntry trackEntry)
		{
			this.m_WasFired = true;
		}

		// Token: 0x0601B688 RID: 112264 RVA: 0x00873DB0 File Offset: 0x008721B0
		private void SafeSubscribe(TrackEntry trackEntry)
		{
			if (trackEntry == null)
			{
				Debug.LogWarning("TrackEntry was null. Coroutine will continue immediately.");
				this.m_WasFired = true;
			}
			else
			{
				trackEntry.End += this.HandleEnd;
			}
		}

		// Token: 0x0601B689 RID: 112265 RVA: 0x00873DE0 File Offset: 0x008721E0
		public WaitForSpineTrackEntryEnd NowWaitFor(TrackEntry trackEntry)
		{
			this.SafeSubscribe(trackEntry);
			return this;
		}

		// Token: 0x0601B68A RID: 112266 RVA: 0x00873DEA File Offset: 0x008721EA
		bool IEnumerator.MoveNext()
		{
			if (this.m_WasFired)
			{
				((IEnumerator)this).Reset();
				return false;
			}
			return true;
		}

		// Token: 0x0601B68B RID: 112267 RVA: 0x00873E00 File Offset: 0x00872200
		void IEnumerator.Reset()
		{
			this.m_WasFired = false;
		}

		// Token: 0x17002458 RID: 9304
		// (get) Token: 0x0601B68C RID: 112268 RVA: 0x00873E09 File Offset: 0x00872209
		object IEnumerator.Current
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0401316C RID: 78188
		private bool m_WasFired;
	}
}
