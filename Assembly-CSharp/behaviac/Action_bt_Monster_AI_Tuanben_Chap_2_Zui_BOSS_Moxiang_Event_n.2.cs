using System;

namespace behaviac
{
	// Token: 0x0200378F RID: 14223
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node4 : Action
	{
		// Token: 0x06015723 RID: 87843 RVA: 0x00679050 File Offset: 0x00677450
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521661;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015724 RID: 87844 RVA: 0x00679088 File Offset: 0x00677488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0D7 RID: 61655
		private BE_Target method_p0;

		// Token: 0x0400F0D8 RID: 61656
		private int method_p1;

		// Token: 0x0400F0D9 RID: 61657
		private int method_p2;

		// Token: 0x0400F0DA RID: 61658
		private int method_p3;

		// Token: 0x0400F0DB RID: 61659
		private int method_p4;
	}
}
