using System;

namespace behaviac
{
	// Token: 0x020025CD RID: 9677
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node111 : Condition
	{
		// Token: 0x060134E1 RID: 79073 RVA: 0x005BD36B File Offset: 0x005BB76B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node111()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130801;
		}

		// Token: 0x060134E2 RID: 79074 RVA: 0x005BD38C File Offset: 0x005BB78C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF21 RID: 53025
		private BE_Target opl_p0;

		// Token: 0x0400CF22 RID: 53026
		private BE_Equal opl_p1;

		// Token: 0x0400CF23 RID: 53027
		private int opl_p2;
	}
}
