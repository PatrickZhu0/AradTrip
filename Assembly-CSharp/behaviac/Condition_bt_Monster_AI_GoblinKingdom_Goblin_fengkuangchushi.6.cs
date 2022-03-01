using System;

namespace behaviac
{
	// Token: 0x0200331C RID: 13084
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node12 : Condition
	{
		// Token: 0x06014E9F RID: 85663 RVA: 0x0064D1F9 File Offset: 0x0064B5F9
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node12()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06014EA0 RID: 85664 RVA: 0x0064D20C File Offset: 0x0064B60C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E78F RID: 59279
		private float opl_p0;
	}
}
