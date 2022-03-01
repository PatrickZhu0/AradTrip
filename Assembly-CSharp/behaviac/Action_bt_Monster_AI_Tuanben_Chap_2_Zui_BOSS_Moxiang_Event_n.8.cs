using System;

namespace behaviac
{
	// Token: 0x0200379E RID: 14238
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node17 : Action
	{
		// Token: 0x06015741 RID: 87873 RVA: 0x00679557 File Offset: 0x00677957
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521671;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015742 RID: 87874 RVA: 0x0067958F File Offset: 0x0067798F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0F0 RID: 61680
		private BE_Target method_p0;

		// Token: 0x0400F0F1 RID: 61681
		private int method_p1;

		// Token: 0x0400F0F2 RID: 61682
		private int method_p2;

		// Token: 0x0400F0F3 RID: 61683
		private int method_p3;

		// Token: 0x0400F0F4 RID: 61684
		private int method_p4;
	}
}
