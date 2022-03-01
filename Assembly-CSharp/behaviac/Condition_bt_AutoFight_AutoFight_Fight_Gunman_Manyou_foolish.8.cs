using System;

namespace behaviac
{
	// Token: 0x02002137 RID: 8503
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node18 : Condition
	{
		// Token: 0x06012C00 RID: 76800 RVA: 0x00582D2B File Offset: 0x0058112B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C01 RID: 76801 RVA: 0x00582D60 File Offset: 0x00581160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5F2 RID: 50674
		private int opl_p0;

		// Token: 0x0400C5F3 RID: 50675
		private int opl_p1;

		// Token: 0x0400C5F4 RID: 50676
		private int opl_p2;

		// Token: 0x0400C5F5 RID: 50677
		private int opl_p3;
	}
}
