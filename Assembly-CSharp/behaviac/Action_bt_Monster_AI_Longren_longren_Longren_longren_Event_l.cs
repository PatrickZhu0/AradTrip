using System;

namespace behaviac
{
	// Token: 0x0200359F RID: 13727
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node15 : Action
	{
		// Token: 0x0601536D RID: 86893 RVA: 0x00664F5F File Offset: 0x0066335F
		public Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBackHit;
		}

		// Token: 0x0601536E RID: 86894 RVA: 0x00664F75 File Offset: 0x00663375
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED37 RID: 60727
		private EventType method_p0;
	}
}
