using System;

namespace behaviac
{
	// Token: 0x02004086 RID: 16518
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node5 : Condition
	{
		// Token: 0x06016868 RID: 92264 RVA: 0x006D2053 File Offset: 0x006D0453
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node5()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016869 RID: 92265 RVA: 0x006D2068 File Offset: 0x006D0468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100B2 RID: 65714
		private float opl_p0;
	}
}
