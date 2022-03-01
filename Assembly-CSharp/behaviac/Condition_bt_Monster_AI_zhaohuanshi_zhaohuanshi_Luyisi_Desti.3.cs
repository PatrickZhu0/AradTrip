using System;

namespace behaviac
{
	// Token: 0x02003FE0 RID: 16352
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node8 : Condition
	{
		// Token: 0x06016727 RID: 91943 RVA: 0x006CAF63 File Offset: 0x006C9363
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node8()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06016728 RID: 91944 RVA: 0x006CAF78 File Offset: 0x006C9378
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF79 RID: 65401
		private float opl_p0;
	}
}
