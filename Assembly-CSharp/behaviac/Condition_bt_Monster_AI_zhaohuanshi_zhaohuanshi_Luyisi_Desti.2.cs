using System;

namespace behaviac
{
	// Token: 0x02003FDE RID: 16350
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node6 : Condition
	{
		// Token: 0x06016723 RID: 91939 RVA: 0x006CAEBF File Offset: 0x006C92BF
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06016724 RID: 91940 RVA: 0x006CAEF4 File Offset: 0x006C92F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF74 RID: 65396
		private int opl_p0;

		// Token: 0x0400FF75 RID: 65397
		private int opl_p1;

		// Token: 0x0400FF76 RID: 65398
		private int opl_p2;

		// Token: 0x0400FF77 RID: 65399
		private int opl_p3;
	}
}
