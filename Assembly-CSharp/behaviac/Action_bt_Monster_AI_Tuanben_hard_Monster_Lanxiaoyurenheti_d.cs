using System;

namespace behaviac
{
	// Token: 0x02003D33 RID: 15667
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3 : Action
	{
		// Token: 0x060161FF RID: 90623 RVA: 0x006B047B File Offset: 0x006AE87B
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81280011;
			this.method_p1 = false;
		}

		// Token: 0x06016200 RID: 90624 RVA: 0x006B049C File Offset: 0x006AE89C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA74 RID: 64116
		private int method_p0;

		// Token: 0x0400FA75 RID: 64117
		private bool method_p1;
	}
}
