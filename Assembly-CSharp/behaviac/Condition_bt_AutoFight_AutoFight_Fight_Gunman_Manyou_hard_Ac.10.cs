using System;

namespace behaviac
{
	// Token: 0x02002163 RID: 8547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node23 : Condition
	{
		// Token: 0x06012C57 RID: 76887 RVA: 0x00584CE3 File Offset: 0x005830E3
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C58 RID: 76888 RVA: 0x00584D18 File Offset: 0x00583118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C649 RID: 50761
		private int opl_p0;

		// Token: 0x0400C64A RID: 50762
		private int opl_p1;

		// Token: 0x0400C64B RID: 50763
		private int opl_p2;

		// Token: 0x0400C64C RID: 50764
		private int opl_p3;
	}
}
