using System;

namespace behaviac
{
	// Token: 0x02002E6E RID: 11886
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node80 : Condition
	{
		// Token: 0x060145B9 RID: 83385 RVA: 0x0061C072 File Offset: 0x0061A472
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node80()
		{
			this.opl_p0 = 21653;
		}

		// Token: 0x060145BA RID: 83386 RVA: 0x0061C088 File Offset: 0x0061A488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF42 RID: 57154
		private int opl_p0;
	}
}
