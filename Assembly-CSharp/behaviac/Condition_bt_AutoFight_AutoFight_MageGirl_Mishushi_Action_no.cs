using System;

namespace behaviac
{
	// Token: 0x020026B0 RID: 9904
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node74 : Condition
	{
		// Token: 0x060136A3 RID: 79523 RVA: 0x005C8642 File Offset: 0x005C6A42
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node74()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060136A4 RID: 79524 RVA: 0x005C8678 File Offset: 0x005C6A78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0F6 RID: 53494
		private int opl_p0;

		// Token: 0x0400D0F7 RID: 53495
		private int opl_p1;

		// Token: 0x0400D0F8 RID: 53496
		private int opl_p2;

		// Token: 0x0400D0F9 RID: 53497
		private int opl_p3;
	}
}
