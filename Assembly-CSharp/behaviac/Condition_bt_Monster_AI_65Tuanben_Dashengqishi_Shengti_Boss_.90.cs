using System;

namespace behaviac
{
	// Token: 0x02002E69 RID: 11881
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node264 : Condition
	{
		// Token: 0x060145AF RID: 83375 RVA: 0x0061BE2A File Offset: 0x0061A22A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node264()
		{
			this.opl_p0 = 21641;
		}

		// Token: 0x060145B0 RID: 83376 RVA: 0x0061BE40 File Offset: 0x0061A240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF39 RID: 57145
		private int opl_p0;
	}
}
