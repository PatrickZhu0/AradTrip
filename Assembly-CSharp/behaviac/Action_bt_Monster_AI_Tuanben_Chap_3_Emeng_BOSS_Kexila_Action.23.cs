using System;

namespace behaviac
{
	// Token: 0x0200387F RID: 14463
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node34 : Action
	{
		// Token: 0x060158E2 RID: 88290 RVA: 0x00681663 File Offset: 0x0067FA63
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node34()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 2;
		}

		// Token: 0x060158E3 RID: 88291 RVA: 0x00681684 File Offset: 0x0067FA84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F27F RID: 62079
		private int method_p0;

		// Token: 0x0400F280 RID: 62080
		private int method_p1;
	}
}
