using System;

namespace behaviac
{
	// Token: 0x02002EDC RID: 11996
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node72 : Condition
	{
		// Token: 0x06014692 RID: 83602 RVA: 0x00622E39 File Offset: 0x00621239
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node72()
		{
			this.opl_p0 = 21594;
		}

		// Token: 0x06014693 RID: 83603 RVA: 0x00622E4C File Offset: 0x0062124C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E007 RID: 57351
		private int opl_p0;
	}
}
