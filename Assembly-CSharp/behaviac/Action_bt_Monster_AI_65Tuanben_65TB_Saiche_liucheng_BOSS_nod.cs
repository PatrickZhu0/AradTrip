using System;

namespace behaviac
{
	// Token: 0x02002BD2 RID: 11218
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node55 : Action
	{
		// Token: 0x060140A3 RID: 82083 RVA: 0x00604E1A File Offset: 0x0060321A
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node55()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
		}

		// Token: 0x060140A4 RID: 82084 RVA: 0x00604E3B File Offset: 0x0060323B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA93 RID: 55955
		private BE_Target method_p0;

		// Token: 0x0400DA94 RID: 55956
		private int method_p1;
	}
}
