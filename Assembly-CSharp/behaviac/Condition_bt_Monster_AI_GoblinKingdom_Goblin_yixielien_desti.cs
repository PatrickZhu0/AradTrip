using System;

namespace behaviac
{
	// Token: 0x0200335E RID: 13150
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node5 : Condition
	{
		// Token: 0x06014F1B RID: 85787 RVA: 0x0064F81E File Offset: 0x0064DC1E
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node5()
		{
			this.opl_p0 = 30230011;
		}

		// Token: 0x06014F1C RID: 85788 RVA: 0x0064F834 File Offset: 0x0064DC34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F4 RID: 59380
		private int opl_p0;
	}
}
