using System;

namespace behaviac
{
	// Token: 0x0200331F RID: 13087
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node14 : Condition
	{
		// Token: 0x06014EA5 RID: 85669 RVA: 0x0064D2E5 File Offset: 0x0064B6E5
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node14()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014EA6 RID: 85670 RVA: 0x0064D2F8 File Offset: 0x0064B6F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E795 RID: 59285
		private float opl_p0;
	}
}
