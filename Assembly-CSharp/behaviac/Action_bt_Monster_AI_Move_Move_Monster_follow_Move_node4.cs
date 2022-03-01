using System;

namespace behaviac
{
	// Token: 0x020036F1 RID: 14065
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node4 : Action
	{
		// Token: 0x060155F4 RID: 87540 RVA: 0x00672C83 File Offset: 0x00671083
		public Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060155F5 RID: 87541 RVA: 0x00672C99 File Offset: 0x00671099
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFC2 RID: 61378
		private DestinationType method_p0;
	}
}
