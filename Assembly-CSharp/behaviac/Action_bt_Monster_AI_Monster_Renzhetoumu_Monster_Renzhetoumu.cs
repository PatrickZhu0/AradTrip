using System;

namespace behaviac
{
	// Token: 0x020036E9 RID: 14057
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node1 : Action
	{
		// Token: 0x060155E6 RID: 87526 RVA: 0x006728AE File Offset: 0x00670CAE
		public Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x060155E7 RID: 87527 RVA: 0x006728C4 File Offset: 0x00670CC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFBB RID: 61371
		private EventType method_p0;
	}
}
