using System;

namespace behaviac
{
	// Token: 0x020031F4 RID: 12788
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node14 : Action
	{
		// Token: 0x06014C74 RID: 85108 RVA: 0x006424D9 File Offset: 0x006408D9
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570275;
		}

		// Token: 0x06014C75 RID: 85109 RVA: 0x006424FA File Offset: 0x006408FA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5CD RID: 58829
		private BE_Target method_p0;

		// Token: 0x0400E5CE RID: 58830
		private int method_p1;
	}
}
