using System;

namespace behaviac
{
	// Token: 0x020021B7 RID: 8631
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node28 : Condition
	{
		// Token: 0x06012CFD RID: 77053 RVA: 0x00588B67 File Offset: 0x00586F67
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012CFE RID: 77054 RVA: 0x00588B9C File Offset: 0x00586F9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6EF RID: 50927
		private int opl_p0;

		// Token: 0x0400C6F0 RID: 50928
		private int opl_p1;

		// Token: 0x0400C6F1 RID: 50929
		private int opl_p2;

		// Token: 0x0400C6F2 RID: 50930
		private int opl_p3;
	}
}
