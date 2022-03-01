using System;

namespace behaviac
{
	// Token: 0x020022D4 RID: 8916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node21 : Condition
	{
		// Token: 0x06012F23 RID: 77603 RVA: 0x005982A7 File Offset: 0x005966A7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node21()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012F24 RID: 77604 RVA: 0x005982DC File Offset: 0x005966DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C938 RID: 51512
		private int opl_p0;

		// Token: 0x0400C939 RID: 51513
		private int opl_p1;

		// Token: 0x0400C93A RID: 51514
		private int opl_p2;

		// Token: 0x0400C93B RID: 51515
		private int opl_p3;
	}
}
