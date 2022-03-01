using System;

namespace behaviac
{
	// Token: 0x02002353 RID: 9043
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node45 : Condition
	{
		// Token: 0x06013013 RID: 77843 RVA: 0x0059EBF9 File Offset: 0x0059CFF9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node45()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x06013014 RID: 77844 RVA: 0x0059EC0C File Offset: 0x0059D00C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA2A RID: 51754
		private int opl_p0;
	}
}
