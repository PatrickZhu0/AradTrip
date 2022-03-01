using System;

namespace behaviac
{
	// Token: 0x0200389D RID: 14493
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2 : Action
	{
		// Token: 0x0601591C RID: 88348 RVA: 0x006830A2 File Offset: 0x006814A2
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521673;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601591D RID: 88349 RVA: 0x006830DA File Offset: 0x006814DA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2AF RID: 62127
		private BE_Target method_p0;

		// Token: 0x0400F2B0 RID: 62128
		private int method_p1;

		// Token: 0x0400F2B1 RID: 62129
		private int method_p2;

		// Token: 0x0400F2B2 RID: 62130
		private int method_p3;

		// Token: 0x0400F2B3 RID: 62131
		private int method_p4;
	}
}
