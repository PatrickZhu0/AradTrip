using System;

namespace behaviac
{
	// Token: 0x02002859 RID: 10329
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node103 : Condition
	{
		// Token: 0x060139F0 RID: 80368 RVA: 0x005DA27F File Offset: 0x005D867F
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node103()
		{
			this.opl_p0 = 3509;
		}

		// Token: 0x060139F1 RID: 80369 RVA: 0x005DA294 File Offset: 0x005D8694
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D449 RID: 54345
		private int opl_p0;
	}
}
