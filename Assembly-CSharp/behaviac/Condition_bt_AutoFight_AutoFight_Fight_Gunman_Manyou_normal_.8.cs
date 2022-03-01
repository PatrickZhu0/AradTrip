using System;

namespace behaviac
{
	// Token: 0x02002187 RID: 8583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node18 : Condition
	{
		// Token: 0x06012C9E RID: 76958 RVA: 0x00586963 File Offset: 0x00584D63
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C9F RID: 76959 RVA: 0x00586998 File Offset: 0x00584D98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C690 RID: 50832
		private int opl_p0;

		// Token: 0x0400C691 RID: 50833
		private int opl_p1;

		// Token: 0x0400C692 RID: 50834
		private int opl_p2;

		// Token: 0x0400C693 RID: 50835
		private int opl_p3;
	}
}
