using System;

namespace behaviac
{
	// Token: 0x02003359 RID: 13145
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node10 : Condition
	{
		// Token: 0x06014F12 RID: 85778 RVA: 0x0064F4A2 File Offset: 0x0064D8A2
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node10()
		{
			this.opl_p0 = 5680;
		}

		// Token: 0x06014F13 RID: 85779 RVA: 0x0064F4B8 File Offset: 0x0064D8B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F0 RID: 59376
		private int opl_p0;
	}
}
