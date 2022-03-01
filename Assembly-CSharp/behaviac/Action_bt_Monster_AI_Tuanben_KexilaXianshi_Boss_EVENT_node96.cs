using System;

namespace behaviac
{
	// Token: 0x02003A8F RID: 14991
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node96 : Action
	{
		// Token: 0x06015CE3 RID: 89315 RVA: 0x00696B1E File Offset: 0x00694F1E
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node96()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
			this.method_p1 = 0;
		}

		// Token: 0x06015CE4 RID: 89316 RVA: 0x00696B3B File Offset: 0x00694F3B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F619 RID: 63001
		private int method_p0;

		// Token: 0x0400F61A RID: 63002
		private int method_p1;
	}
}
