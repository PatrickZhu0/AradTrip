using System;

namespace behaviac
{
	// Token: 0x0200394C RID: 14668
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9 : Action
	{
		// Token: 0x06015A72 RID: 88690 RVA: 0x0068A773 File Offset: 0x00688B73
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 4000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A73 RID: 88691 RVA: 0x0068A7AB File Offset: 0x00688BAB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F400 RID: 62464
		private BE_Target method_p0;

		// Token: 0x0400F401 RID: 62465
		private int method_p1;

		// Token: 0x0400F402 RID: 62466
		private int method_p2;

		// Token: 0x0400F403 RID: 62467
		private int method_p3;

		// Token: 0x0400F404 RID: 62468
		private int method_p4;
	}
}
