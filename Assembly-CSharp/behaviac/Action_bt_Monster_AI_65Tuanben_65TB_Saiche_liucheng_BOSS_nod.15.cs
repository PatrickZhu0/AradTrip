using System;

namespace behaviac
{
	// Token: 0x02002BF3 RID: 11251
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node90 : Action
	{
		// Token: 0x060140E5 RID: 82149 RVA: 0x006057C9 File Offset: 0x00603BC9
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node90()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2;
			this.method_p2 = 90000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x060140E6 RID: 82150 RVA: 0x00605800 File Offset: 0x00603C00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAC8 RID: 56008
		private BE_Target method_p0;

		// Token: 0x0400DAC9 RID: 56009
		private int method_p1;

		// Token: 0x0400DACA RID: 56010
		private int method_p2;

		// Token: 0x0400DACB RID: 56011
		private int method_p3;

		// Token: 0x0400DACC RID: 56012
		private int method_p4;
	}
}
