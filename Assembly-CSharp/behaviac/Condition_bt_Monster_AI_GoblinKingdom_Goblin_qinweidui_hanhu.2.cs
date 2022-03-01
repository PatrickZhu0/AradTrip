using System;

namespace behaviac
{
	// Token: 0x02003355 RID: 13141
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node9 : Condition
	{
		// Token: 0x06014F0A RID: 85770 RVA: 0x0064F37E File Offset: 0x0064D77E
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node9()
		{
			this.opl_p0 = 5679;
		}

		// Token: 0x06014F0B RID: 85771 RVA: 0x0064F394 File Offset: 0x0064D794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7E9 RID: 59369
		private int opl_p0;
	}
}
