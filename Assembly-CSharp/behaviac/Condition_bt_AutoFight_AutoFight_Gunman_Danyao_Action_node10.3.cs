using System;

namespace behaviac
{
	// Token: 0x020025B5 RID: 9653
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node102 : Condition
	{
		// Token: 0x060134B1 RID: 79025 RVA: 0x005BC99B File Offset: 0x005BAD9B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node102()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130801;
		}

		// Token: 0x060134B2 RID: 79026 RVA: 0x005BC9BC File Offset: 0x005BADBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEE9 RID: 52969
		private BE_Target opl_p0;

		// Token: 0x0400CEEA RID: 52970
		private BE_Equal opl_p1;

		// Token: 0x0400CEEB RID: 52971
		private int opl_p2;
	}
}
