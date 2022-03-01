using System;

namespace behaviac
{
	// Token: 0x02003D21 RID: 15649
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node3 : Action
	{
		// Token: 0x060161DD RID: 90589 RVA: 0x006AFA6F File Offset: 0x006ADE6F
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81300011;
			this.method_p1 = false;
		}

		// Token: 0x060161DE RID: 90590 RVA: 0x006AFA90 File Offset: 0x006ADE90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA5F RID: 64095
		private int method_p0;

		// Token: 0x0400FA60 RID: 64096
		private bool method_p1;
	}
}
