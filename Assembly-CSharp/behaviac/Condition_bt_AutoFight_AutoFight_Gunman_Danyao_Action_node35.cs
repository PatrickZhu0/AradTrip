using System;

namespace behaviac
{
	// Token: 0x020025A5 RID: 9637
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node35 : Condition
	{
		// Token: 0x06013491 RID: 78993 RVA: 0x005BC2FE File Offset: 0x005BA6FE
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node35()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013492 RID: 78994 RVA: 0x005BC334 File Offset: 0x005BA734
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEC5 RID: 52933
		private int opl_p0;

		// Token: 0x0400CEC6 RID: 52934
		private int opl_p1;

		// Token: 0x0400CEC7 RID: 52935
		private int opl_p2;

		// Token: 0x0400CEC8 RID: 52936
		private int opl_p3;
	}
}
