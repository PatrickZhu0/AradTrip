using System;

namespace behaviac
{
	// Token: 0x020028D9 RID: 10457
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node80 : Condition
	{
		// Token: 0x06013AEC RID: 80620 RVA: 0x005E04B2 File Offset: 0x005DE8B2
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node80()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013AED RID: 80621 RVA: 0x005E04C8 File Offset: 0x005DE8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D54E RID: 54606
		private float opl_p0;
	}
}
