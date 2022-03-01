using System;

namespace behaviac
{
	// Token: 0x02003D48 RID: 15688
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node5 : Action
	{
		// Token: 0x06016226 RID: 90662 RVA: 0x006B0AF7 File Offset: 0x006AEEF7
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570070;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06016227 RID: 90663 RVA: 0x006B0B2E File Offset: 0x006AEF2E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA87 RID: 64135
		private BE_Target method_p0;

		// Token: 0x0400FA88 RID: 64136
		private int method_p1;

		// Token: 0x0400FA89 RID: 64137
		private int method_p2;

		// Token: 0x0400FA8A RID: 64138
		private int method_p3;

		// Token: 0x0400FA8B RID: 64139
		private int method_p4;
	}
}
