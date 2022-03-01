using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000D3F RID: 3391
	public class GeUIEffectGeoPool
	{
		// Token: 0x06008A16 RID: 35350 RVA: 0x0019417D File Offset: 0x0019257D
		public void Init(int vertices)
		{
			this.m_GeoVertCnt = vertices;
		}

		// Token: 0x06008A17 RID: 35351 RVA: 0x00194186 File Offset: 0x00192586
		public void Deinit()
		{
			this.Clear();
		}

		// Token: 0x06008A18 RID: 35352 RVA: 0x0019418E File Offset: 0x0019258E
		public void Clear()
		{
			this.m_UIEffectGeoList.Clear();
		}

		// Token: 0x06008A19 RID: 35353 RVA: 0x0019419C File Offset: 0x0019259C
		public GeUIEffectGeo AllocGeometry()
		{
			for (int i = 0; i < this.m_UIEffectGeoList.Count; i++)
			{
				if (!this.m_UIEffectGeoList[i].UnderUsed)
				{
					return this.m_UIEffectGeoList[i];
				}
			}
			return this._Expand();
		}

		// Token: 0x06008A1A RID: 35354 RVA: 0x001941F0 File Offset: 0x001925F0
		protected GeUIEffectGeo _Expand()
		{
			GeUIEffectGeo geUIEffectGeo = new GeUIEffectGeo(this.m_GeoVertCnt);
			this.m_UIEffectGeoList.Add(geUIEffectGeo);
			return geUIEffectGeo;
		}

		// Token: 0x040043FF RID: 17407
		private List<GeUIEffectGeo> m_UIEffectGeoList = new List<GeUIEffectGeo>();

		// Token: 0x04004400 RID: 17408
		private int m_GeoVertCnt;
	}
}
