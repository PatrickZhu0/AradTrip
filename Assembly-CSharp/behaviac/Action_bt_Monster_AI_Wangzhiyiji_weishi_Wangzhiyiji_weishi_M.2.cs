using System;

namespace behaviac
{
	// Token: 0x02003DAA RID: 15786
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node6 : Action
	{
		// Token: 0x060162E5 RID: 90853 RVA: 0x006B4AB3 File Offset: 0x006B2EB3
		public Action_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060162E6 RID: 90854 RVA: 0x006B4AC9 File Offset: 0x006B2EC9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB2D RID: 64301
		private DestinationType method_p0;
	}
}
