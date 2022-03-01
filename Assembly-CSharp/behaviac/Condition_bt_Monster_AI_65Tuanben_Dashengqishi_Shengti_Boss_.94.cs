using System;

namespace behaviac
{
	// Token: 0x02002E70 RID: 11888
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node271 : Condition
	{
		// Token: 0x060145BD RID: 83389 RVA: 0x0061C166 File Offset: 0x0061A566
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node271()
		{
			this.opl_p0 = 21637;
		}

		// Token: 0x060145BE RID: 83390 RVA: 0x0061C17C File Offset: 0x0061A57C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF45 RID: 57157
		private int opl_p0;
	}
}
