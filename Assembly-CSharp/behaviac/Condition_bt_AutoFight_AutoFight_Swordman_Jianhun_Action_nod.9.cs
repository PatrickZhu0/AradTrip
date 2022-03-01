using System;

namespace behaviac
{
	// Token: 0x0200290F RID: 10511
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node32 : Condition
	{
		// Token: 0x06013B54 RID: 80724 RVA: 0x005E3D42 File Offset: 0x005E2142
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node32()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013B55 RID: 80725 RVA: 0x005E3D74 File Offset: 0x005E2174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5B8 RID: 54712
		private int opl_p0;

		// Token: 0x0400D5B9 RID: 54713
		private int opl_p1;

		// Token: 0x0400D5BA RID: 54714
		private int opl_p2;

		// Token: 0x0400D5BB RID: 54715
		private int opl_p3;
	}
}
