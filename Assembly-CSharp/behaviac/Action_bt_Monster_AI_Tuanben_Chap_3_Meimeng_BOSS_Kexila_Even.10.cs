using System;

namespace behaviac
{
	// Token: 0x0200395B RID: 14683
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node34 : Action
	{
		// Token: 0x06015A8D RID: 88717 RVA: 0x0068AEF7 File Offset: 0x006892F7
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A8E RID: 88718 RVA: 0x0068AF2E File Offset: 0x0068932E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F423 RID: 62499
		private BE_Target method_p0;

		// Token: 0x0400F424 RID: 62500
		private int method_p1;

		// Token: 0x0400F425 RID: 62501
		private int method_p2;

		// Token: 0x0400F426 RID: 62502
		private int method_p3;

		// Token: 0x0400F427 RID: 62503
		private int method_p4;
	}
}
