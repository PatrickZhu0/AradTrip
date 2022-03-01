using System;

namespace behaviac
{
	// Token: 0x0200225E RID: 8798
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12 : Condition
	{
		// Token: 0x06012E44 RID: 77380 RVA: 0x00591AC6 File Offset: 0x0058FEC6
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012E45 RID: 77381 RVA: 0x00591AFC File Offset: 0x0058FEFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C851 RID: 51281
		private int opl_p0;

		// Token: 0x0400C852 RID: 51282
		private int opl_p1;

		// Token: 0x0400C853 RID: 51283
		private int opl_p2;

		// Token: 0x0400C854 RID: 51284
		private int opl_p3;
	}
}
