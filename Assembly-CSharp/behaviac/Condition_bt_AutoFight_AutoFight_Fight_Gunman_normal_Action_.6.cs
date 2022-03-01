using System;

namespace behaviac
{
	// Token: 0x020021D3 RID: 8659
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node13 : Condition
	{
		// Token: 0x06012D34 RID: 77108 RVA: 0x0058A3FF File Offset: 0x005887FF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D35 RID: 77109 RVA: 0x0058A434 File Offset: 0x00588834
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C726 RID: 50982
		private int opl_p0;

		// Token: 0x0400C727 RID: 50983
		private int opl_p1;

		// Token: 0x0400C728 RID: 50984
		private int opl_p2;

		// Token: 0x0400C729 RID: 50985
		private int opl_p3;
	}
}
