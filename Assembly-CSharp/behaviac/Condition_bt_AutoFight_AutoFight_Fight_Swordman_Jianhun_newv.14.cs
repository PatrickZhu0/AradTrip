using System;

namespace behaviac
{
	// Token: 0x020022C0 RID: 8896
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node53 : Condition
	{
		// Token: 0x06012EFB RID: 77563 RVA: 0x00596A7B File Offset: 0x00594E7B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node53()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06012EFC RID: 77564 RVA: 0x00596AB0 File Offset: 0x00594EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C90C RID: 51468
		private int opl_p0;

		// Token: 0x0400C90D RID: 51469
		private int opl_p1;

		// Token: 0x0400C90E RID: 51470
		private int opl_p2;

		// Token: 0x0400C90F RID: 51471
		private int opl_p3;
	}
}
