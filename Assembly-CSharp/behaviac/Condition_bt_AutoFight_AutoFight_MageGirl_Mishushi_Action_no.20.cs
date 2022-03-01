using System;

namespace behaviac
{
	// Token: 0x020026C9 RID: 9929
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node64 : Condition
	{
		// Token: 0x060136D5 RID: 79573 RVA: 0x005C90EE File Offset: 0x005C74EE
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node64()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1500;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060136D6 RID: 79574 RVA: 0x005C9124 File Offset: 0x005C7524
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D12B RID: 53547
		private int opl_p0;

		// Token: 0x0400D12C RID: 53548
		private int opl_p1;

		// Token: 0x0400D12D RID: 53549
		private int opl_p2;

		// Token: 0x0400D12E RID: 53550
		private int opl_p3;
	}
}
