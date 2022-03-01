using System;

namespace behaviac
{
	// Token: 0x020022DB RID: 8923
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node12 : Condition
	{
		// Token: 0x06012F31 RID: 77617 RVA: 0x0059884B File Offset: 0x00596C4B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node12()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012F32 RID: 77618 RVA: 0x00598880 File Offset: 0x00596C80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C947 RID: 51527
		private int opl_p0;

		// Token: 0x0400C948 RID: 51528
		private int opl_p1;

		// Token: 0x0400C949 RID: 51529
		private int opl_p2;

		// Token: 0x0400C94A RID: 51530
		private int opl_p3;
	}
}
