using System;

namespace behaviac
{
	// Token: 0x020035AC RID: 13740
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node9 : Action
	{
		// Token: 0x06015386 RID: 86918 RVA: 0x00665757 File Offset: 0x00663B57
		public Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06015387 RID: 86919 RVA: 0x0066576D File Offset: 0x00663B6D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED53 RID: 60755
		private EventType method_p0;
	}
}
