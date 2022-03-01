using System;

namespace behaviac
{
	// Token: 0x0200216F RID: 8559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node38 : Condition
	{
		// Token: 0x06012C6F RID: 76911 RVA: 0x00585267 File Offset: 0x00583667
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012C70 RID: 76912 RVA: 0x0058529C File Offset: 0x0058369C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C661 RID: 50785
		private int opl_p0;

		// Token: 0x0400C662 RID: 50786
		private int opl_p1;

		// Token: 0x0400C663 RID: 50787
		private int opl_p2;

		// Token: 0x0400C664 RID: 50788
		private int opl_p3;
	}
}
