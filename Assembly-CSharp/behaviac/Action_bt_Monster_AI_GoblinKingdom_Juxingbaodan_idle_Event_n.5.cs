using System;

namespace behaviac
{
	// Token: 0x0200337D RID: 13181
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node23 : Action
	{
		// Token: 0x06014F57 RID: 85847 RVA: 0x0065089E File Offset: 0x0064EC9E
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node23()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 0;
		}

		// Token: 0x06014F58 RID: 85848 RVA: 0x006508C0 File Offset: 0x0064ECC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E81F RID: 59423
		private int method_p0;

		// Token: 0x0400E820 RID: 59424
		private int method_p1;
	}
}
