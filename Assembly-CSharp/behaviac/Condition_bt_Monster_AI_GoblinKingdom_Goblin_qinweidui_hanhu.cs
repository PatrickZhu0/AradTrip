using System;

namespace behaviac
{
	// Token: 0x02003353 RID: 13139
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node0 : Condition
	{
		// Token: 0x06014F06 RID: 85766 RVA: 0x0064F2F1 File Offset: 0x0064D6F1
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node0()
		{
			this.opl_p0 = 5679;
		}

		// Token: 0x06014F07 RID: 85767 RVA: 0x0064F304 File Offset: 0x0064D704
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7E6 RID: 59366
		private int opl_p0;
	}
}
