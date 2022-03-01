using System;

namespace behaviac
{
	// Token: 0x02002882 RID: 10370
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node11 : Condition
	{
		// Token: 0x06013A41 RID: 80449 RVA: 0x005DCF27 File Offset: 0x005DB327
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node11()
		{
			this.opl_p0 = 1521;
		}

		// Token: 0x06013A42 RID: 80450 RVA: 0x005DCF3C File Offset: 0x005DB33C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D49B RID: 54427
		private int opl_p0;
	}
}
