using System;

namespace behaviac
{
	// Token: 0x02002BE6 RID: 11238
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node5 : Action
	{
		// Token: 0x060140CB RID: 82123 RVA: 0x006053DE File Offset: 0x006037DE
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
			this.method_p2 = 50000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060140CC RID: 82124 RVA: 0x00605418 File Offset: 0x00603818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAAD RID: 55981
		private BE_Target method_p0;

		// Token: 0x0400DAAE RID: 55982
		private int method_p1;

		// Token: 0x0400DAAF RID: 55983
		private int method_p2;

		// Token: 0x0400DAB0 RID: 55984
		private int method_p3;

		// Token: 0x0400DAB1 RID: 55985
		private int method_p4;
	}
}
