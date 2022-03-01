using System;

namespace behaviac
{
	// Token: 0x02002388 RID: 9096
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node50 : Condition
	{
		// Token: 0x06013077 RID: 77943 RVA: 0x005A1133 File Offset: 0x0059F533
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node50()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x06013078 RID: 77944 RVA: 0x005A1148 File Offset: 0x0059F548
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA8E RID: 51854
		private int opl_p0;
	}
}
