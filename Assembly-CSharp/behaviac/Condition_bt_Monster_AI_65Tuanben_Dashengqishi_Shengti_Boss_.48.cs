using System;

namespace behaviac
{
	// Token: 0x02002E1E RID: 11806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node134 : Condition
	{
		// Token: 0x06014519 RID: 83225 RVA: 0x0061A115 File Offset: 0x00618515
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node134()
		{
			this.opl_p0 = 21624;
		}

		// Token: 0x0601451A RID: 83226 RVA: 0x0061A128 File Offset: 0x00618528
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEC1 RID: 57025
		private int opl_p0;
	}
}
