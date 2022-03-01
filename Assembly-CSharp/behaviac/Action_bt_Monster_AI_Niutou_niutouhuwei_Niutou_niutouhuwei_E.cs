using System;

namespace behaviac
{
	// Token: 0x02003709 RID: 14089
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node11 : Action
	{
		// Token: 0x06015620 RID: 87584 RVA: 0x00673978 File Offset: 0x00671D78
		public Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBackHit;
		}

		// Token: 0x06015621 RID: 87585 RVA: 0x0067398E File Offset: 0x00671D8E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFE9 RID: 61417
		private EventType method_p0;
	}
}
