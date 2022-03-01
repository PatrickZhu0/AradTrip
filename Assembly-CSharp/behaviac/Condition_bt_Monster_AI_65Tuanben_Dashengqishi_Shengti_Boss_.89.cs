using System;

namespace behaviac
{
	// Token: 0x02002E67 RID: 11879
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node259 : Condition
	{
		// Token: 0x060145AB RID: 83371 RVA: 0x0061BD36 File Offset: 0x0061A136
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node259()
		{
			this.opl_p0 = 21628;
		}

		// Token: 0x060145AC RID: 83372 RVA: 0x0061BD4C File Offset: 0x0061A14C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF36 RID: 57142
		private int opl_p0;
	}
}
