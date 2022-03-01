using System;

namespace behaviac
{
	// Token: 0x02002955 RID: 10581
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node45 : Condition
	{
		// Token: 0x06013BDF RID: 80863 RVA: 0x005E7217 File Offset: 0x005E5617
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node45()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x06013BE0 RID: 80864 RVA: 0x005E722C File Offset: 0x005E562C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D645 RID: 54853
		private int opl_p0;
	}
}
