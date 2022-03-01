using System;

namespace behaviac
{
	// Token: 0x0200214F RID: 8527
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node48 : Condition
	{
		// Token: 0x06012C30 RID: 76848 RVA: 0x0058388F File Offset: 0x00581C8F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node48()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C31 RID: 76849 RVA: 0x005838C4 File Offset: 0x00581CC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C622 RID: 50722
		private int opl_p0;

		// Token: 0x0400C623 RID: 50723
		private int opl_p1;

		// Token: 0x0400C624 RID: 50724
		private int opl_p2;

		// Token: 0x0400C625 RID: 50725
		private int opl_p3;
	}
}
