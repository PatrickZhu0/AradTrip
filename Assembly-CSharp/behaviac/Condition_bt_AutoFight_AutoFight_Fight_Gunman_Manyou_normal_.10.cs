using System;

namespace behaviac
{
	// Token: 0x0200218B RID: 8587
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node23 : Condition
	{
		// Token: 0x06012CA6 RID: 76966 RVA: 0x00586AFF File Offset: 0x00584EFF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012CA7 RID: 76967 RVA: 0x00586B34 File Offset: 0x00584F34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C698 RID: 50840
		private int opl_p0;

		// Token: 0x0400C699 RID: 50841
		private int opl_p1;

		// Token: 0x0400C69A RID: 50842
		private int opl_p2;

		// Token: 0x0400C69B RID: 50843
		private int opl_p3;
	}
}
