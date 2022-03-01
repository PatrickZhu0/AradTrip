using System;

namespace behaviac
{
	// Token: 0x02002BF8 RID: 11256
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node75 : Action
	{
		// Token: 0x060140EF RID: 82159 RVA: 0x006058FE File Offset: 0x00603CFE
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node75()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
			this.method_p2 = 50000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060140F0 RID: 82160 RVA: 0x00605938 File Offset: 0x00603D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DACF RID: 56015
		private BE_Target method_p0;

		// Token: 0x0400DAD0 RID: 56016
		private int method_p1;

		// Token: 0x0400DAD1 RID: 56017
		private int method_p2;

		// Token: 0x0400DAD2 RID: 56018
		private int method_p3;

		// Token: 0x0400DAD3 RID: 56019
		private int method_p4;
	}
}
