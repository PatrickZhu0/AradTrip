using System;

namespace behaviac
{
	// Token: 0x02002BFF RID: 11263
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node97 : Action
	{
		// Token: 0x060140FD RID: 82173 RVA: 0x00605AB2 File Offset: 0x00603EB2
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node97()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521383;
			this.method_p2 = 1000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060140FE RID: 82174 RVA: 0x00605AEC File Offset: 0x00603EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DADB RID: 56027
		private BE_Target method_p0;

		// Token: 0x0400DADC RID: 56028
		private int method_p1;

		// Token: 0x0400DADD RID: 56029
		private int method_p2;

		// Token: 0x0400DADE RID: 56030
		private int method_p3;

		// Token: 0x0400DADF RID: 56031
		private int method_p4;
	}
}
