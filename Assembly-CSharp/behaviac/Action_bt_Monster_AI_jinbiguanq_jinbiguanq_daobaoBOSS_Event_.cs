using System;

namespace behaviac
{
	// Token: 0x0200357A RID: 13690
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node4 : Action
	{
		// Token: 0x06015327 RID: 86823 RVA: 0x0066381B File Offset: 0x00661C1B
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
			this.method_p2 = 3000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015328 RID: 86824 RVA: 0x00663851 File Offset: 0x00661C51
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECE7 RID: 60647
		private BE_Target method_p0;

		// Token: 0x0400ECE8 RID: 60648
		private int method_p1;

		// Token: 0x0400ECE9 RID: 60649
		private int method_p2;

		// Token: 0x0400ECEA RID: 60650
		private int method_p3;

		// Token: 0x0400ECEB RID: 60651
		private int method_p4;
	}
}
