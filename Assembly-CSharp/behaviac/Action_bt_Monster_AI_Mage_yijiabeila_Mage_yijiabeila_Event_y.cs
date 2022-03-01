using System;

namespace behaviac
{
	// Token: 0x020035B4 RID: 13748
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node8 : Action
	{
		// Token: 0x06015395 RID: 86933 RVA: 0x00665C21 File Offset: 0x00664021
		public Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06015396 RID: 86934 RVA: 0x00665C37 File Offset: 0x00664037
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED60 RID: 60768
		private EventType method_p0;
	}
}
