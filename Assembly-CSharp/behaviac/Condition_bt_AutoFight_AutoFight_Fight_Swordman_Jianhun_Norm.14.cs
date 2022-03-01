using System;

namespace behaviac
{
	// Token: 0x020022FB RID: 8955
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node31 : Condition
	{
		// Token: 0x06012F6F RID: 77679 RVA: 0x0059AD50 File Offset: 0x00599150
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node31()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
			this.opl_p4 = 4000;
			this.opl_p5 = 4000;
			this.opl_p6 = 4000;
			this.opl_p7 = 4000;
		}

		// Token: 0x06012F70 RID: 77680 RVA: 0x0059ADBC File Offset: 0x005991BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C985 RID: 51589
		private int opl_p0;

		// Token: 0x0400C986 RID: 51590
		private int opl_p1;

		// Token: 0x0400C987 RID: 51591
		private int opl_p2;

		// Token: 0x0400C988 RID: 51592
		private int opl_p3;

		// Token: 0x0400C989 RID: 51593
		private int opl_p4;

		// Token: 0x0400C98A RID: 51594
		private int opl_p5;

		// Token: 0x0400C98B RID: 51595
		private int opl_p6;

		// Token: 0x0400C98C RID: 51596
		private int opl_p7;
	}
}
