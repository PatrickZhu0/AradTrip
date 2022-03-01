using System;

namespace behaviac
{
	// Token: 0x02003F89 RID: 16265
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node7 : Condition
	{
		// Token: 0x0601667D RID: 91773 RVA: 0x006C735B File Offset: 0x006C575B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node7()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x0601667E RID: 91774 RVA: 0x006C7370 File Offset: 0x006C5770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FED1 RID: 65233
		private float opl_p0;
	}
}
