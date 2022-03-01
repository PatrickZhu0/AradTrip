using System;

namespace behaviac
{
	// Token: 0x02003361 RID: 13153
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node9 : Condition
	{
		// Token: 0x06014F21 RID: 85793 RVA: 0x0064F8CB File Offset: 0x0064DCCB
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node9()
		{
			this.opl_p0 = 30230011;
		}

		// Token: 0x06014F22 RID: 85794 RVA: 0x0064F8E0 File Offset: 0x0064DCE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F6 RID: 59382
		private int opl_p0;
	}
}
