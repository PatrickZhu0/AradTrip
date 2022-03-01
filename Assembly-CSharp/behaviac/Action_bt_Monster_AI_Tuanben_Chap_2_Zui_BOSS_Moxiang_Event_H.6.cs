using System;

namespace behaviac
{
	// Token: 0x020037B0 RID: 14256
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node26 : Action
	{
		// Token: 0x06015763 RID: 87907 RVA: 0x0067A121 File Offset: 0x00678521
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521693;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015764 RID: 87908 RVA: 0x0067A158 File Offset: 0x00678558
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F10D RID: 61709
		private BE_Target method_p0;

		// Token: 0x0400F10E RID: 61710
		private int method_p1;

		// Token: 0x0400F10F RID: 61711
		private int method_p2;

		// Token: 0x0400F110 RID: 61712
		private int method_p3;

		// Token: 0x0400F111 RID: 61713
		private int method_p4;
	}
}
