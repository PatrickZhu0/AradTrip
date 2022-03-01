using System;

namespace behaviac
{
	// Token: 0x02002598 RID: 9624
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node92 : Condition
	{
		// Token: 0x06013477 RID: 78967 RVA: 0x005BBDB7 File Offset: 0x005BA1B7
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node92()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130204;
		}

		// Token: 0x06013478 RID: 78968 RVA: 0x005BBDD8 File Offset: 0x005BA1D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEA6 RID: 52902
		private BE_Target opl_p0;

		// Token: 0x0400CEA7 RID: 52903
		private BE_Equal opl_p1;

		// Token: 0x0400CEA8 RID: 52904
		private int opl_p2;
	}
}
