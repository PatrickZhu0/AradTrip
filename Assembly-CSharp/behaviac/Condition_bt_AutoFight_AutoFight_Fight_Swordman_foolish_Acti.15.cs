using System;

namespace behaviac
{
	// Token: 0x02002293 RID: 8851
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node31 : Condition
	{
		// Token: 0x06012EA6 RID: 77478 RVA: 0x00594417 File Offset: 0x00592817
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node31()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012EA7 RID: 77479 RVA: 0x0059444C File Offset: 0x0059284C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8B0 RID: 51376
		private int opl_p0;

		// Token: 0x0400C8B1 RID: 51377
		private int opl_p1;

		// Token: 0x0400C8B2 RID: 51378
		private int opl_p2;

		// Token: 0x0400C8B3 RID: 51379
		private int opl_p3;
	}
}
