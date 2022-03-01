using System;

namespace behaviac
{
	// Token: 0x020025BD RID: 9661
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node31 : Condition
	{
		// Token: 0x060134C1 RID: 79041 RVA: 0x005BCCCE File Offset: 0x005BB0CE
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node31()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060134C2 RID: 79042 RVA: 0x005BCD04 File Offset: 0x005BB104
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEFD RID: 52989
		private int opl_p0;

		// Token: 0x0400CEFE RID: 52990
		private int opl_p1;

		// Token: 0x0400CEFF RID: 52991
		private int opl_p2;

		// Token: 0x0400CF00 RID: 52992
		private int opl_p3;
	}
}
