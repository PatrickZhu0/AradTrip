using System;

namespace behaviac
{
	// Token: 0x02002E06 RID: 11782
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node103 : Condition
	{
		// Token: 0x060144E9 RID: 83177 RVA: 0x0061969B File Offset: 0x00617A9B
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node103()
		{
			this.opl_p0 = 21631;
		}

		// Token: 0x060144EA RID: 83178 RVA: 0x006196B0 File Offset: 0x00617AB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE93 RID: 56979
		private int opl_p0;
	}
}
