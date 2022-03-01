using System;

namespace behaviac
{
	// Token: 0x0200344F RID: 13391
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node35 : Action
	{
		// Token: 0x060150EA RID: 86250 RVA: 0x00658356 File Offset: 0x00656756
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521856;
		}

		// Token: 0x060150EB RID: 86251 RVA: 0x00658377 File Offset: 0x00656777
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9CA RID: 59850
		private BE_Target method_p0;

		// Token: 0x0400E9CB RID: 59851
		private int method_p1;
	}
}
