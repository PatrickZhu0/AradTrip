using System;

namespace behaviac
{
	// Token: 0x02003364 RID: 13156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node12 : Condition
	{
		// Token: 0x06014F27 RID: 85799 RVA: 0x0064F974 File Offset: 0x0064DD74
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node12()
		{
			this.opl_p0 = 30230011;
		}

		// Token: 0x06014F28 RID: 85800 RVA: 0x0064F988 File Offset: 0x0064DD88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F8 RID: 59384
		private int opl_p0;
	}
}
