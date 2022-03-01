using System;

namespace behaviac
{
	// Token: 0x0200222F RID: 8751
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node24 : Condition
	{
		// Token: 0x06012DE8 RID: 77288 RVA: 0x0058EC6B File Offset: 0x0058D06B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node24()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012DE9 RID: 77289 RVA: 0x0058ECA0 File Offset: 0x0058D0A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7E6 RID: 51174
		private int opl_p0;

		// Token: 0x0400C7E7 RID: 51175
		private int opl_p1;

		// Token: 0x0400C7E8 RID: 51176
		private int opl_p2;

		// Token: 0x0400C7E9 RID: 51177
		private int opl_p3;
	}
}
