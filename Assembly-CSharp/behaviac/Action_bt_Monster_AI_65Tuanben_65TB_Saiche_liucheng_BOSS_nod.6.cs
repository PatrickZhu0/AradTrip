using System;

namespace behaviac
{
	// Token: 0x02002BE1 RID: 11233
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node82 : Action
	{
		// Token: 0x060140C1 RID: 82113 RVA: 0x006052A9 File Offset: 0x006036A9
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node82()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2;
			this.method_p2 = 90000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x060140C2 RID: 82114 RVA: 0x006052E0 File Offset: 0x006036E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAA6 RID: 55974
		private BE_Target method_p0;

		// Token: 0x0400DAA7 RID: 55975
		private int method_p1;

		// Token: 0x0400DAA8 RID: 55976
		private int method_p2;

		// Token: 0x0400DAA9 RID: 55977
		private int method_p3;

		// Token: 0x0400DAAA RID: 55978
		private int method_p4;
	}
}
