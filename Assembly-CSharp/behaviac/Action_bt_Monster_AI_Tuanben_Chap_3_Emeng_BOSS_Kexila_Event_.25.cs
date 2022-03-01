using System;

namespace behaviac
{
	// Token: 0x020038C4 RID: 14532
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node15 : Action
	{
		// Token: 0x06015967 RID: 88423 RVA: 0x0068410F File Offset: 0x0068250F
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521641;
			this.method_p2 = 1000;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06015968 RID: 88424 RVA: 0x0068414A File Offset: 0x0068254A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F313 RID: 62227
		private BE_Target method_p0;

		// Token: 0x0400F314 RID: 62228
		private int method_p1;

		// Token: 0x0400F315 RID: 62229
		private int method_p2;

		// Token: 0x0400F316 RID: 62230
		private int method_p3;

		// Token: 0x0400F317 RID: 62231
		private int method_p4;
	}
}
