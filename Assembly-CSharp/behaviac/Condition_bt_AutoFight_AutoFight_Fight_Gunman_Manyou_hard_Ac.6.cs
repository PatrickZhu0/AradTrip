using System;

namespace behaviac
{
	// Token: 0x0200215B RID: 8539
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node13 : Condition
	{
		// Token: 0x06012C47 RID: 76871 RVA: 0x005848FB File Offset: 0x00582CFB
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C48 RID: 76872 RVA: 0x00584930 File Offset: 0x00582D30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C639 RID: 50745
		private int opl_p0;

		// Token: 0x0400C63A RID: 50746
		private int opl_p1;

		// Token: 0x0400C63B RID: 50747
		private int opl_p2;

		// Token: 0x0400C63C RID: 50748
		private int opl_p3;
	}
}
