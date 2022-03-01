using System;

namespace behaviac
{
	// Token: 0x02003319 RID: 13081
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7 : Condition
	{
		// Token: 0x06014E99 RID: 85657 RVA: 0x0064D10D File Offset: 0x0064B50D
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06014E9A RID: 85658 RVA: 0x0064D120 File Offset: 0x0064B520
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E789 RID: 59273
		private float opl_p0;
	}
}
