using System;

namespace behaviac
{
	// Token: 0x0200321A RID: 12826
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node9 : Action
	{
		// Token: 0x06014CBD RID: 85181 RVA: 0x00644113 File Offset: 0x00642513
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 4000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014CBE RID: 85182 RVA: 0x0064414B File Offset: 0x0064254B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E603 RID: 58883
		private BE_Target method_p0;

		// Token: 0x0400E604 RID: 58884
		private int method_p1;

		// Token: 0x0400E605 RID: 58885
		private int method_p2;

		// Token: 0x0400E606 RID: 58886
		private int method_p3;

		// Token: 0x0400E607 RID: 58887
		private int method_p4;
	}
}
