using System;

namespace behaviac
{
	// Token: 0x02002944 RID: 10564
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node7 : Condition
	{
		// Token: 0x06013BBD RID: 80829 RVA: 0x005E6AEF File Offset: 0x005E4EEF
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node7()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x06013BBE RID: 80830 RVA: 0x005E6B04 File Offset: 0x005E4F04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D622 RID: 54818
		private int opl_p0;
	}
}
