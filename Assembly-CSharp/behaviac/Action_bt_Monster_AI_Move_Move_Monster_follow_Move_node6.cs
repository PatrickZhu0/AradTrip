using System;

namespace behaviac
{
	// Token: 0x020036F3 RID: 14067
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node6 : Action
	{
		// Token: 0x060155F8 RID: 87544 RVA: 0x00672CF3 File Offset: 0x006710F3
		public Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060155F9 RID: 87545 RVA: 0x00672D09 File Offset: 0x00671109
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFC4 RID: 61380
		private DestinationType method_p0;
	}
}
