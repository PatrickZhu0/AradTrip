using System;

namespace behaviac
{
	// Token: 0x02002C69 RID: 11369
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node2 : Action
	{
		// Token: 0x060141CB RID: 82379 RVA: 0x0060A548 File Offset: 0x00608948
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521985;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x060141CC RID: 82380 RVA: 0x0060A57F File Offset: 0x0060897F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB85 RID: 56197
		private BE_Target method_p0;

		// Token: 0x0400DB86 RID: 56198
		private int method_p1;

		// Token: 0x0400DB87 RID: 56199
		private int method_p2;

		// Token: 0x0400DB88 RID: 56200
		private int method_p3;

		// Token: 0x0400DB89 RID: 56201
		private int method_p4;
	}
}
