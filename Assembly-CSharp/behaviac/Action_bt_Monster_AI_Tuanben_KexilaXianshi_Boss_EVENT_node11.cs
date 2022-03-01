using System;

namespace behaviac
{
	// Token: 0x02003A8A RID: 14986
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node113 : Action
	{
		// Token: 0x06015CD9 RID: 89305 RVA: 0x006969D5 File Offset: 0x00694DD5
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node113()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570106;
		}

		// Token: 0x06015CDA RID: 89306 RVA: 0x006969F6 File Offset: 0x00694DF6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F610 RID: 62992
		private BE_Target method_p0;

		// Token: 0x0400F611 RID: 62993
		private int method_p1;
	}
}
