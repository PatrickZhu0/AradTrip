using System;

namespace behaviac
{
	// Token: 0x020025CB RID: 9675
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node109 : Condition
	{
		// Token: 0x060134DD RID: 79069 RVA: 0x005BD2AB File Offset: 0x005BB6AB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node109()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130303;
		}

		// Token: 0x060134DE RID: 79070 RVA: 0x005BD2CC File Offset: 0x005BB6CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF1B RID: 53019
		private BE_Target opl_p0;

		// Token: 0x0400CF1C RID: 53020
		private BE_Equal opl_p1;

		// Token: 0x0400CF1D RID: 53021
		private int opl_p2;
	}
}
