using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001916 RID: 6422
	public class MallActivityExchangeParams : MonoBehaviour
	{
		// Token: 0x04009C23 RID: 39971
		public List<MallActivityExchangeParams.ExchangeGoodParams> ExchangeGoodParamList = new List<MallActivityExchangeParams.ExchangeGoodParams>();

		// Token: 0x02001917 RID: 6423
		[Serializable]
		public class ExchangeGoodParams
		{
			// Token: 0x04009C24 RID: 39972
			public int ShopId;

			// Token: 0x04009C25 RID: 39973
			public int GoodId;

			// Token: 0x04009C26 RID: 39974
			public int Count;
		}
	}
}
