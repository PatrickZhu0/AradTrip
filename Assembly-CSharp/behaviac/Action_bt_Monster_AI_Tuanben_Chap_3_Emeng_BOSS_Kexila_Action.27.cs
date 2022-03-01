using System;

namespace behaviac
{
	// Token: 0x0200388B RID: 14475
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node65 : Action
	{
		// Token: 0x060158FA RID: 88314 RVA: 0x00681B0A File Offset: 0x0067FF0A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node65()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 3000;
			this.method_p1 = 3;
		}

		// Token: 0x060158FB RID: 88315 RVA: 0x00681B2C File Offset: 0x0067FF2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F291 RID: 62097
		private int method_p0;

		// Token: 0x0400F292 RID: 62098
		private int method_p1;
	}
}
