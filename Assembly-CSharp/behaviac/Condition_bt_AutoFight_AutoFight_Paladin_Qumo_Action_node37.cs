using System;

namespace behaviac
{
	// Token: 0x020027D3 RID: 10195
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node37 : Condition
	{
		// Token: 0x060138E5 RID: 80101 RVA: 0x005D4DE6 File Offset: 0x005D31E6
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node37()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060138E6 RID: 80102 RVA: 0x005D4E1C File Offset: 0x005D321C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D343 RID: 54083
		private int opl_p0;

		// Token: 0x0400D344 RID: 54084
		private int opl_p1;

		// Token: 0x0400D345 RID: 54085
		private int opl_p2;

		// Token: 0x0400D346 RID: 54086
		private int opl_p3;
	}
}
