using System;

namespace behaviac
{
	// Token: 0x02002C1C RID: 11292
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node52 : Action
	{
		// Token: 0x06014137 RID: 82231 RVA: 0x0060632B File Offset: 0x0060472B
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node52()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
			this.method_p2 = 50000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06014138 RID: 82232 RVA: 0x00606365 File Offset: 0x00604765
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB06 RID: 56070
		private BE_Target method_p0;

		// Token: 0x0400DB07 RID: 56071
		private int method_p1;

		// Token: 0x0400DB08 RID: 56072
		private int method_p2;

		// Token: 0x0400DB09 RID: 56073
		private int method_p3;

		// Token: 0x0400DB0A RID: 56074
		private int method_p4;
	}
}
