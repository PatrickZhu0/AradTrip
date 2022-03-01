using System;

namespace behaviac
{
	// Token: 0x02002BE0 RID: 11232
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node1 : Action
	{
		// Token: 0x060140BF RID: 82111 RVA: 0x00605243 File Offset: 0x00603643
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522221;
			this.method_p2 = 5000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060140C0 RID: 82112 RVA: 0x0060527D File Offset: 0x0060367D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAA1 RID: 55969
		private BE_Target method_p0;

		// Token: 0x0400DAA2 RID: 55970
		private int method_p1;

		// Token: 0x0400DAA3 RID: 55971
		private int method_p2;

		// Token: 0x0400DAA4 RID: 55972
		private int method_p3;

		// Token: 0x0400DAA5 RID: 55973
		private int method_p4;
	}
}
