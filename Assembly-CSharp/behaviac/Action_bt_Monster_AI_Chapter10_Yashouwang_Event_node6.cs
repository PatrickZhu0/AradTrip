using System;

namespace behaviac
{
	// Token: 0x0200314C RID: 12620
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Yashouwang_Event_node6 : Action
	{
		// Token: 0x06014B3A RID: 84794 RVA: 0x0063C0BB File Offset: 0x0063A4BB
		public Action_bt_Monster_AI_Chapter10_Yashouwang_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
		}

		// Token: 0x06014B3B RID: 84795 RVA: 0x0063C0CA File Offset: 0x0063A4CA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveAbnormalBuffs();
			return EBTStatus.BT_SUCCESS;
		}
	}
}
