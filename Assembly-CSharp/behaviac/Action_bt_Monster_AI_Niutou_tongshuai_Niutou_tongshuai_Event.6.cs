using System;

namespace behaviac
{
	// Token: 0x0200372C RID: 14124
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node15 : Action
	{
		// Token: 0x06015664 RID: 87652 RVA: 0x00674BD8 File Offset: 0x00672FD8
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538801;
			this.method_p2 = 60000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015665 RID: 87653 RVA: 0x00674C12 File Offset: 0x00673012
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F02E RID: 61486
		private BE_Target method_p0;

		// Token: 0x0400F02F RID: 61487
		private int method_p1;

		// Token: 0x0400F030 RID: 61488
		private int method_p2;

		// Token: 0x0400F031 RID: 61489
		private int method_p3;

		// Token: 0x0400F032 RID: 61490
		private int method_p4;
	}
}
