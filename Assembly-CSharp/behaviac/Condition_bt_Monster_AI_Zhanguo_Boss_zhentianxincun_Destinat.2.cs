using System;

namespace behaviac
{
	// Token: 0x02003ED1 RID: 16081
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node0 : Condition
	{
		// Token: 0x0601651E RID: 91422 RVA: 0x006C0969 File Offset: 0x006BED69
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node0()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x0601651F RID: 91423 RVA: 0x006C09A0 File Offset: 0x006BEDA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD53 RID: 64851
		private int opl_p0;

		// Token: 0x0400FD54 RID: 64852
		private int opl_p1;

		// Token: 0x0400FD55 RID: 64853
		private int opl_p2;

		// Token: 0x0400FD56 RID: 64854
		private int opl_p3;
	}
}
