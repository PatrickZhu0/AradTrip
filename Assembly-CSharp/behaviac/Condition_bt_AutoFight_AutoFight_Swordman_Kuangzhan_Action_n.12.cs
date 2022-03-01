using System;

namespace behaviac
{
	// Token: 0x02002951 RID: 10577
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node35 : Condition
	{
		// Token: 0x06013BD7 RID: 80855 RVA: 0x005E7063 File Offset: 0x005E5463
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node35()
		{
			this.opl_p0 = 1521;
		}

		// Token: 0x06013BD8 RID: 80856 RVA: 0x005E7078 File Offset: 0x005E5478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D63D RID: 54845
		private int opl_p0;
	}
}
