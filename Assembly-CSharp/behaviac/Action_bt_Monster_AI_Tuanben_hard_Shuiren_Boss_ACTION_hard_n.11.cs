using System;

namespace behaviac
{
	// Token: 0x02003D55 RID: 15701
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node29 : Action
	{
		// Token: 0x06016240 RID: 90688 RVA: 0x006B0F33 File Offset: 0x006AF333
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570070;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06016241 RID: 90689 RVA: 0x006B0F6A File Offset: 0x006AF36A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA9E RID: 64158
		private BE_Target method_p0;

		// Token: 0x0400FA9F RID: 64159
		private int method_p1;

		// Token: 0x0400FAA0 RID: 64160
		private int method_p2;

		// Token: 0x0400FAA1 RID: 64161
		private int method_p3;

		// Token: 0x0400FAA2 RID: 64162
		private int method_p4;
	}
}
