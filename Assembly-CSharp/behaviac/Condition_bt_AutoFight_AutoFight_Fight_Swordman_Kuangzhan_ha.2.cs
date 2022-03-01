using System;

namespace behaviac
{
	// Token: 0x02002365 RID: 9061
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node7 : Condition
	{
		// Token: 0x06013035 RID: 77877 RVA: 0x005A022B File Offset: 0x0059E62B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node7()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x06013036 RID: 77878 RVA: 0x005A0240 File Offset: 0x0059E640
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA4D RID: 51789
		private int opl_p0;
	}
}
