using System;

namespace behaviac
{
	// Token: 0x02002972 RID: 10610
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node26 : Condition
	{
		// Token: 0x06013C19 RID: 80921 RVA: 0x005E7EE1 File Offset: 0x005E62E1
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node26()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013C1A RID: 80922 RVA: 0x005E7EF4 File Offset: 0x005E62F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D680 RID: 54912
		private float opl_p0;
	}
}
