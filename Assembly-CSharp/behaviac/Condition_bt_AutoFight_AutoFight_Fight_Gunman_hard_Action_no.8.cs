using System;

namespace behaviac
{
	// Token: 0x020020F7 RID: 8439
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node18 : Condition
	{
		// Token: 0x06012B82 RID: 76674 RVA: 0x0057FCFF File Offset: 0x0057E0FF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B83 RID: 76675 RVA: 0x0057FD34 File Offset: 0x0057E134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C574 RID: 50548
		private int opl_p0;

		// Token: 0x0400C575 RID: 50549
		private int opl_p1;

		// Token: 0x0400C576 RID: 50550
		private int opl_p2;

		// Token: 0x0400C577 RID: 50551
		private int opl_p3;
	}
}
