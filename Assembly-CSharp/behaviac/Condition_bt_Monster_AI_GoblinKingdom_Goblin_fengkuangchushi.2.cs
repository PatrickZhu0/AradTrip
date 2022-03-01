using System;

namespace behaviac
{
	// Token: 0x02003316 RID: 13078
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5 : Condition
	{
		// Token: 0x06014E93 RID: 85651 RVA: 0x0064D020 File Offset: 0x0064B420
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06014E94 RID: 85652 RVA: 0x0064D034 File Offset: 0x0064B434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E783 RID: 59267
		private float opl_p0;
	}
}
