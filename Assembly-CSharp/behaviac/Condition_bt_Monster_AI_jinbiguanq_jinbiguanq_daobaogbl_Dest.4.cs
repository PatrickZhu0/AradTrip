using System;

namespace behaviac
{
	// Token: 0x02003583 RID: 13699
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node11 : Condition
	{
		// Token: 0x06015338 RID: 86840 RVA: 0x00663CE3 File Offset: 0x006620E3
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node11()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06015339 RID: 86841 RVA: 0x00663D18 File Offset: 0x00662118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECF9 RID: 60665
		private int opl_p0;

		// Token: 0x0400ECFA RID: 60666
		private int opl_p1;

		// Token: 0x0400ECFB RID: 60667
		private int opl_p2;

		// Token: 0x0400ECFC RID: 60668
		private int opl_p3;
	}
}
