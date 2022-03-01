using System;

namespace behaviac
{
	// Token: 0x02002375 RID: 9077
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node27 : Condition
	{
		// Token: 0x06013052 RID: 77906 RVA: 0x005A08DF File Offset: 0x0059ECDF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06013053 RID: 77907 RVA: 0x005A08F4 File Offset: 0x0059ECF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA68 RID: 51816
		private int opl_p0;
	}
}
