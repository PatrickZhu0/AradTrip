using System;

namespace behaviac
{
	// Token: 0x0200204F RID: 8271
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node28 : Condition
	{
		// Token: 0x06012A38 RID: 76344 RVA: 0x005778A3 File Offset: 0x00575CA3
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012A39 RID: 76345 RVA: 0x005778D8 File Offset: 0x00575CD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C42A RID: 50218
		private int opl_p0;

		// Token: 0x0400C42B RID: 50219
		private int opl_p1;

		// Token: 0x0400C42C RID: 50220
		private int opl_p2;

		// Token: 0x0400C42D RID: 50221
		private int opl_p3;
	}
}
