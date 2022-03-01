using System;

namespace behaviac
{
	// Token: 0x02002167 RID: 8551
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node28 : Condition
	{
		// Token: 0x06012C5F RID: 76895 RVA: 0x00584F2F File Offset: 0x0058332F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012C60 RID: 76896 RVA: 0x00584F64 File Offset: 0x00583364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C651 RID: 50769
		private int opl_p0;

		// Token: 0x0400C652 RID: 50770
		private int opl_p1;

		// Token: 0x0400C653 RID: 50771
		private int opl_p2;

		// Token: 0x0400C654 RID: 50772
		private int opl_p3;
	}
}
