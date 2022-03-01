using System;

namespace behaviac
{
	// Token: 0x020035F1 RID: 13809
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node30 : Action
	{
		// Token: 0x06015408 RID: 87048 RVA: 0x006681AF File Offset: 0x006665AF
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06015409 RID: 87049 RVA: 0x006681C5 File Offset: 0x006665C5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDC2 RID: 60866
		private EventType method_p0;
	}
}
