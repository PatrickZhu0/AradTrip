using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020011D3 RID: 4563
	public class ExpeditionMapBaseInfo
	{
		// Token: 0x0600AF00 RID: 44800 RVA: 0x00264012 File Offset: 0x00262412
		public ExpeditionMapBaseInfo()
		{
			this.expeditionMapDic = new Dictionary<int, ExpeditionMapModel>();
		}

		// Token: 0x0600AF01 RID: 44801 RVA: 0x00264028 File Offset: 0x00262428
		public void Clear()
		{
			if (this.expeditionMapDic != null)
			{
				foreach (KeyValuePair<int, ExpeditionMapModel> keyValuePair in this.expeditionMapDic)
				{
					ExpeditionMapModel value = keyValuePair.Value;
					if (value != null)
					{
						value.Clear();
					}
				}
				this.expeditionMapDic.Clear();
			}
		}

		// Token: 0x040061FE RID: 25086
		public Dictionary<int, ExpeditionMapModel> expeditionMapDic;
	}
}
