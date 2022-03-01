using System;

namespace behaviac
{
	// Token: 0x02003A8C RID: 14988
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node6 : Action
	{
		// Token: 0x06015CDD RID: 89309 RVA: 0x00696A73 File Offset: 0x00694E73
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570144;
		}

		// Token: 0x06015CDE RID: 89310 RVA: 0x00696A94 File Offset: 0x00694E94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F615 RID: 62997
		private BE_Target method_p0;

		// Token: 0x0400F616 RID: 62998
		private int method_p1;
	}
}
