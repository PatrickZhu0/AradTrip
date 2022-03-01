using System;

namespace behaviac
{
	// Token: 0x02003B14 RID: 15124
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3 : Action
	{
		// Token: 0x06015DE1 RID: 89569 RVA: 0x0069B95B File Offset: 0x00699D5B
		public Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80010011;
			this.method_p1 = false;
		}

		// Token: 0x06015DE2 RID: 89570 RVA: 0x0069B97C File Offset: 0x00699D7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6CC RID: 63180
		private int method_p0;

		// Token: 0x0400F6CD RID: 63181
		private bool method_p1;
	}
}
