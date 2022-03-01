using System;

namespace behaviac
{
	// Token: 0x0200336A RID: 13162
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node20 : Condition
	{
		// Token: 0x06014F33 RID: 85811 RVA: 0x0064FAED File Offset: 0x0064DEED
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node20()
		{
			this.opl_p0 = 30230011;
		}

		// Token: 0x06014F34 RID: 85812 RVA: 0x0064FB00 File Offset: 0x0064DF00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7FE RID: 59390
		private int opl_p0;
	}
}
