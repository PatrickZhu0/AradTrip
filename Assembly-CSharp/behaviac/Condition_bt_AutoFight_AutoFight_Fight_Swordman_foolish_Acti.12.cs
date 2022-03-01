using System;

namespace behaviac
{
	// Token: 0x0200228E RID: 8846
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node25 : Condition
	{
		// Token: 0x06012E9C RID: 77468 RVA: 0x0059421F File Offset: 0x0059261F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node25()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 100;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012E9D RID: 77469 RVA: 0x00594250 File Offset: 0x00592650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8A5 RID: 51365
		private int opl_p0;

		// Token: 0x0400C8A6 RID: 51366
		private int opl_p1;

		// Token: 0x0400C8A7 RID: 51367
		private int opl_p2;

		// Token: 0x0400C8A8 RID: 51368
		private int opl_p3;
	}
}
