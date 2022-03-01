using System;

namespace behaviac
{
	// Token: 0x02003B02 RID: 15106
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node3 : Action
	{
		// Token: 0x06015DBF RID: 89535 RVA: 0x0069AF4F File Offset: 0x0069934F
		public Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80030011;
			this.method_p1 = false;
		}

		// Token: 0x06015DC0 RID: 89536 RVA: 0x0069AF70 File Offset: 0x00699370
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6B7 RID: 63159
		private int method_p0;

		// Token: 0x0400F6B8 RID: 63160
		private bool method_p1;
	}
}
