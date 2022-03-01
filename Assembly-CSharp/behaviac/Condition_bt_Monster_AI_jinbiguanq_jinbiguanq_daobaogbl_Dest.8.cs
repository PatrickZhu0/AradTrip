using System;

namespace behaviac
{
	// Token: 0x02003589 RID: 13705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node17 : Condition
	{
		// Token: 0x06015344 RID: 86852 RVA: 0x00663EBB File Offset: 0x006622BB
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node17()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x06015345 RID: 86853 RVA: 0x00663EF0 File Offset: 0x006622F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED05 RID: 60677
		private int opl_p0;

		// Token: 0x0400ED06 RID: 60678
		private int opl_p1;

		// Token: 0x0400ED07 RID: 60679
		private int opl_p2;

		// Token: 0x0400ED08 RID: 60680
		private int opl_p3;
	}
}
