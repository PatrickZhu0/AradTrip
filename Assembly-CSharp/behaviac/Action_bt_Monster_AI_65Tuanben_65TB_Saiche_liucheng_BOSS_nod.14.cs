using System;

namespace behaviac
{
	// Token: 0x02002BF2 RID: 11250
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node68 : Action
	{
		// Token: 0x060140E3 RID: 82147 RVA: 0x00605763 File Offset: 0x00603B63
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node68()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522221;
			this.method_p2 = 5000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060140E4 RID: 82148 RVA: 0x0060579D File Offset: 0x00603B9D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAC3 RID: 56003
		private BE_Target method_p0;

		// Token: 0x0400DAC4 RID: 56004
		private int method_p1;

		// Token: 0x0400DAC5 RID: 56005
		private int method_p2;

		// Token: 0x0400DAC6 RID: 56006
		private int method_p3;

		// Token: 0x0400DAC7 RID: 56007
		private int method_p4;
	}
}
