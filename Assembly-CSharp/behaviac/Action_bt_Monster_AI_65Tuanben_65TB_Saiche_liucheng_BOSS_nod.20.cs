using System;

namespace behaviac
{
	// Token: 0x02002BFE RID: 11262
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node112 : Action
	{
		// Token: 0x060140FB RID: 82171 RVA: 0x00605A77 File Offset: 0x00603E77
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node112()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
		}

		// Token: 0x060140FC RID: 82172 RVA: 0x00605A98 File Offset: 0x00603E98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAD9 RID: 56025
		private BE_Target method_p0;

		// Token: 0x0400DADA RID: 56026
		private int method_p1;
	}
}
