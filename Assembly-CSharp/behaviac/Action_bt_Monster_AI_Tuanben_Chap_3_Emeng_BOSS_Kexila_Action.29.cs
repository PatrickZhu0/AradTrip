using System;

namespace behaviac
{
	// Token: 0x0200388F RID: 14479
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node66 : Action
	{
		// Token: 0x06015902 RID: 88322 RVA: 0x00681C8E File Offset: 0x0068008E
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node66()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 3000;
			this.method_p1 = 4;
		}

		// Token: 0x06015903 RID: 88323 RVA: 0x00681CB0 File Offset: 0x006800B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F297 RID: 62103
		private int method_p0;

		// Token: 0x0400F298 RID: 62104
		private int method_p1;
	}
}
