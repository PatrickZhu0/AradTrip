using System;

namespace behaviac
{
	// Token: 0x02003590 RID: 13712
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node7 : Action
	{
		// Token: 0x06015351 RID: 86865 RVA: 0x00664523 File Offset: 0x00662923
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 500000;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015352 RID: 86866 RVA: 0x00664559 File Offset: 0x00662959
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED16 RID: 60694
		private BE_Target method_p0;

		// Token: 0x0400ED17 RID: 60695
		private int method_p1;

		// Token: 0x0400ED18 RID: 60696
		private int method_p2;

		// Token: 0x0400ED19 RID: 60697
		private int method_p3;

		// Token: 0x0400ED1A RID: 60698
		private int method_p4;
	}
}
