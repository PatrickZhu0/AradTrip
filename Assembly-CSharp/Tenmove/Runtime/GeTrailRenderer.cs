using System;
using System.Collections;
using UnityEngine;

namespace Tenmove.Runtime
{
	// Token: 0x02000D07 RID: 3335
	[RequireComponent(typeof(TrailRenderer))]
	public class GeTrailRenderer : MonoBehaviour
	{
		// Token: 0x06008829 RID: 34857 RVA: 0x00183EE5 File Offset: 0x001822E5
		private void Awake()
		{
			if (null != this.m_TrailRenderer)
			{
				this.m_OriginTime = this.m_TrailRenderer.time;
			}
		}

		// Token: 0x0600882A RID: 34858 RVA: 0x00183F0C File Offset: 0x0018230C
		private void OnEnable()
		{
			if (null == this.m_TrailRenderer)
			{
				this.m_TrailRenderer = base.GetComponent<TrailRenderer>();
			}
			if (null != this.m_TrailRenderer)
			{
				this.m_TrailRenderer.time = 0.001f;
				base.StartCoroutine(this._RecoverRendererTime());
			}
		}

		// Token: 0x0600882B RID: 34859 RVA: 0x00183F64 File Offset: 0x00182364
		private IEnumerator _RecoverRendererTime()
		{
			yield return Yielders.GetWaitForSeconds(0.066f);
			if (null != this.m_TrailRenderer)
			{
				this.m_TrailRenderer.time = this.m_OriginTime;
			}
			yield break;
		}

		// Token: 0x04004200 RID: 16896
		public TrailRenderer m_TrailRenderer;

		// Token: 0x04004201 RID: 16897
		private float m_OriginTime;
	}
}
