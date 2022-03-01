using System;

namespace behaviac
{
	// Token: 0x02003580 RID: 13696
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node8 : Condition
	{
		// Token: 0x06015332 RID: 86834 RVA: 0x00663BF7 File Offset: 0x00661FF7
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node8()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06015333 RID: 86835 RVA: 0x00663C2C File Offset: 0x0066202C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECF3 RID: 60659
		private int opl_p0;

		// Token: 0x0400ECF4 RID: 60660
		private int opl_p1;

		// Token: 0x0400ECF5 RID: 60661
		private int opl_p2;

		// Token: 0x0400ECF6 RID: 60662
		private int opl_p3;
	}
}
