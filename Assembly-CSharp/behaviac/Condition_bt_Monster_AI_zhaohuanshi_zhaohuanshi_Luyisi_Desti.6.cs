using System;

namespace behaviac
{
	// Token: 0x02003FE4 RID: 16356
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node13 : Condition
	{
		// Token: 0x0601672F RID: 91951 RVA: 0x006CB097 File Offset: 0x006C9497
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node13()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x06016730 RID: 91952 RVA: 0x006CB0CC File Offset: 0x006C94CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF80 RID: 65408
		private int opl_p0;

		// Token: 0x0400FF81 RID: 65409
		private int opl_p1;

		// Token: 0x0400FF82 RID: 65410
		private int opl_p2;

		// Token: 0x0400FF83 RID: 65411
		private int opl_p3;
	}
}
