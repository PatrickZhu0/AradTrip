using System;

namespace behaviac
{
	// Token: 0x020021E3 RID: 8675
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node3 : Condition
	{
		// Token: 0x06012D53 RID: 77139 RVA: 0x0058B2D7 File Offset: 0x005896D7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D54 RID: 77140 RVA: 0x0058B30C File Offset: 0x0058970C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C745 RID: 51013
		private int opl_p0;

		// Token: 0x0400C746 RID: 51014
		private int opl_p1;

		// Token: 0x0400C747 RID: 51015
		private int opl_p2;

		// Token: 0x0400C748 RID: 51016
		private int opl_p3;
	}
}
