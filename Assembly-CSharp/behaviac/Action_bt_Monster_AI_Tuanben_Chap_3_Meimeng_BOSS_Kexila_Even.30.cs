using System;

namespace behaviac
{
	// Token: 0x0200397F RID: 14719
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node19 : Action
	{
		// Token: 0x06015AD5 RID: 88789 RVA: 0x0068BA5E File Offset: 0x00689E5E
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521679;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015AD6 RID: 88790 RVA: 0x0068BA95 File Offset: 0x00689E95
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F478 RID: 62584
		private BE_Target method_p0;

		// Token: 0x0400F479 RID: 62585
		private int method_p1;

		// Token: 0x0400F47A RID: 62586
		private int method_p2;

		// Token: 0x0400F47B RID: 62587
		private int method_p3;

		// Token: 0x0400F47C RID: 62588
		private int method_p4;
	}
}
