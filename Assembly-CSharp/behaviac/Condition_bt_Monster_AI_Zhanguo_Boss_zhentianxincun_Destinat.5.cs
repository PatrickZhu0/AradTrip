using System;

namespace behaviac
{
	// Token: 0x02003ED5 RID: 16085
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node14 : Condition
	{
		// Token: 0x06016526 RID: 91430 RVA: 0x006C0AD5 File Offset: 0x006BEED5
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node14()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016527 RID: 91431 RVA: 0x006C0B0C File Offset: 0x006BEF0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD5D RID: 64861
		private int opl_p0;

		// Token: 0x0400FD5E RID: 64862
		private int opl_p1;

		// Token: 0x0400FD5F RID: 64863
		private int opl_p2;

		// Token: 0x0400FD60 RID: 64864
		private int opl_p3;
	}
}
