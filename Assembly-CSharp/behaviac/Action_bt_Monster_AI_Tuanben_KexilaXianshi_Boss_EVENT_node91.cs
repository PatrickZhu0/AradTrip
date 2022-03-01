using System;

namespace behaviac
{
	// Token: 0x02003A89 RID: 14985
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node91 : Action
	{
		// Token: 0x06015CD7 RID: 89303 RVA: 0x006969AB File Offset: 0x00694DAB
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node91()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015CD8 RID: 89304 RVA: 0x006969C1 File Offset: 0x00694DC1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F60F RID: 62991
		private int method_p0;
	}
}
