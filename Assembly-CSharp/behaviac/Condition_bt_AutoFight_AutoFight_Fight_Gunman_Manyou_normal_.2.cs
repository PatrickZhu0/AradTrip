using System;

namespace behaviac
{
	// Token: 0x0200217B RID: 8571
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node3 : Condition
	{
		// Token: 0x06012C86 RID: 76934 RVA: 0x005863DF File Offset: 0x005847DF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012C87 RID: 76935 RVA: 0x00586414 File Offset: 0x00584814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C678 RID: 50808
		private int opl_p0;

		// Token: 0x0400C679 RID: 50809
		private int opl_p1;

		// Token: 0x0400C67A RID: 50810
		private int opl_p2;

		// Token: 0x0400C67B RID: 50811
		private int opl_p3;
	}
}
