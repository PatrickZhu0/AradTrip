using System;

namespace behaviac
{
	// Token: 0x02002E43 RID: 11843
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node210 : Condition
	{
		// Token: 0x06014563 RID: 83299 RVA: 0x0061AE52 File Offset: 0x00619252
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node210()
		{
			this.opl_p0 = 21629;
		}

		// Token: 0x06014564 RID: 83300 RVA: 0x0061AE68 File Offset: 0x00619268
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEF5 RID: 57077
		private int opl_p0;
	}
}
