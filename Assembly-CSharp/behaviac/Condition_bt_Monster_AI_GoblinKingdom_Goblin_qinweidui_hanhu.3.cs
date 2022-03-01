using System;

namespace behaviac
{
	// Token: 0x02003357 RID: 13143
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node6 : Condition
	{
		// Token: 0x06014F0E RID: 85774 RVA: 0x0064F413 File Offset: 0x0064D813
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node6()
		{
			this.opl_p0 = 5680;
		}

		// Token: 0x06014F0F RID: 85775 RVA: 0x0064F428 File Offset: 0x0064D828
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7ED RID: 59373
		private int opl_p0;
	}
}
