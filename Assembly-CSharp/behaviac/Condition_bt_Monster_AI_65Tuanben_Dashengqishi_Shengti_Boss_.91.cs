using System;

namespace behaviac
{
	// Token: 0x02002E6B RID: 11883
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node267 : Condition
	{
		// Token: 0x060145B3 RID: 83379 RVA: 0x0061BF1E File Offset: 0x0061A31E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node267()
		{
			this.opl_p0 = 21629;
		}

		// Token: 0x060145B4 RID: 83380 RVA: 0x0061BF34 File Offset: 0x0061A334
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF3C RID: 57148
		private int opl_p0;
	}
}
