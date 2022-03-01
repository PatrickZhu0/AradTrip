using System;

namespace behaviac
{
	// Token: 0x02002413 RID: 9235
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node13 : Condition
	{
		// Token: 0x06013182 RID: 78210 RVA: 0x005A9A07 File Offset: 0x005A7E07
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013183 RID: 78211 RVA: 0x005A9A1C File Offset: 0x005A7E1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBAE RID: 52142
		private int opl_p0;
	}
}
