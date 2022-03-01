using System;

namespace behaviac
{
	// Token: 0x020037B4 RID: 14260
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node17 : Action
	{
		// Token: 0x0601576B RID: 87915 RVA: 0x0067A23F File Offset: 0x0067863F
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521671;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601576C RID: 87916 RVA: 0x0067A277 File Offset: 0x00678677
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F115 RID: 61717
		private BE_Target method_p0;

		// Token: 0x0400F116 RID: 61718
		private int method_p1;

		// Token: 0x0400F117 RID: 61719
		private int method_p2;

		// Token: 0x0400F118 RID: 61720
		private int method_p3;

		// Token: 0x0400F119 RID: 61721
		private int method_p4;
	}
}
