using System;

namespace behaviac
{
	// Token: 0x02003960 RID: 14688
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node37 : Action
	{
		// Token: 0x06015A97 RID: 88727 RVA: 0x0068B0BB File Offset: 0x006894BB
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570212;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A98 RID: 88728 RVA: 0x0068B0F2 File Offset: 0x006894F2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F434 RID: 62516
		private BE_Target method_p0;

		// Token: 0x0400F435 RID: 62517
		private int method_p1;

		// Token: 0x0400F436 RID: 62518
		private int method_p2;

		// Token: 0x0400F437 RID: 62519
		private int method_p3;

		// Token: 0x0400F438 RID: 62520
		private int method_p4;
	}
}
