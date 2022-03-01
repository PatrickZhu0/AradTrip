using System;

namespace behaviac
{
	// Token: 0x020028D6 RID: 10454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node76 : Condition
	{
		// Token: 0x06013AE6 RID: 80614 RVA: 0x005E02EE File Offset: 0x005DE6EE
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node76()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013AE7 RID: 80615 RVA: 0x005E0304 File Offset: 0x005DE704
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D547 RID: 54599
		private float opl_p0;
	}
}
