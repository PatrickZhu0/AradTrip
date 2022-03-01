using System;

namespace behaviac
{
	// Token: 0x02003DA8 RID: 15784
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node4 : Action
	{
		// Token: 0x060162E1 RID: 90849 RVA: 0x006B4A43 File Offset: 0x006B2E43
		public Action_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060162E2 RID: 90850 RVA: 0x006B4A59 File Offset: 0x006B2E59
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB2B RID: 64299
		private DestinationType method_p0;
	}
}
