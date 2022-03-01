using System;

namespace behaviac
{
	// Token: 0x0200288D RID: 10381
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node85 : Condition
	{
		// Token: 0x06013A57 RID: 80471 RVA: 0x005DD423 File Offset: 0x005DB823
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node85()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013A58 RID: 80472 RVA: 0x005DD458 File Offset: 0x005DB858
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4AF RID: 54447
		private int opl_p0;

		// Token: 0x0400D4B0 RID: 54448
		private int opl_p1;

		// Token: 0x0400D4B1 RID: 54449
		private int opl_p2;

		// Token: 0x0400D4B2 RID: 54450
		private int opl_p3;
	}
}
