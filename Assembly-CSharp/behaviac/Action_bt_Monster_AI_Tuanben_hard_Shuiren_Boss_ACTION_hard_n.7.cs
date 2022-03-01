using System;

namespace behaviac
{
	// Token: 0x02003D4E RID: 15694
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node17 : Action
	{
		// Token: 0x06016232 RID: 90674 RVA: 0x006B0CFF File Offset: 0x006AF0FF
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570070;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06016233 RID: 90675 RVA: 0x006B0D36 File Offset: 0x006AF136
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA92 RID: 64146
		private BE_Target method_p0;

		// Token: 0x0400FA93 RID: 64147
		private int method_p1;

		// Token: 0x0400FA94 RID: 64148
		private int method_p2;

		// Token: 0x0400FA95 RID: 64149
		private int method_p3;

		// Token: 0x0400FA96 RID: 64150
		private int method_p4;
	}
}
