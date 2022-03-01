using System;

namespace behaviac
{
	// Token: 0x0200354F RID: 13647
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node106 : Action
	{
		// Token: 0x060152DE RID: 86750 RVA: 0x00662273 File Offset: 0x00660673
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node106()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521757;
		}

		// Token: 0x060152DF RID: 86751 RVA: 0x00662294 File Offset: 0x00660694
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC96 RID: 60566
		private BE_Target method_p0;

		// Token: 0x0400EC97 RID: 60567
		private int method_p1;
	}
}
