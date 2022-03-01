using System;

namespace behaviac
{
	// Token: 0x020022C7 RID: 8903
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node38 : Condition
	{
		// Token: 0x06012F09 RID: 77577 RVA: 0x00597687 File Offset: 0x00595A87
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node38()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3500;
			this.opl_p3 = 3500;
		}

		// Token: 0x06012F0A RID: 77578 RVA: 0x005976BC File Offset: 0x00595ABC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C91B RID: 51483
		private int opl_p0;

		// Token: 0x0400C91C RID: 51484
		private int opl_p1;

		// Token: 0x0400C91D RID: 51485
		private int opl_p2;

		// Token: 0x0400C91E RID: 51486
		private int opl_p3;
	}
}
