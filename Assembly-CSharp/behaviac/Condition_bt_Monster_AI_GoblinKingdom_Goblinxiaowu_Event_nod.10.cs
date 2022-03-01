using System;

namespace behaviac
{
	// Token: 0x020032EC RID: 13036
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node38 : Condition
	{
		// Token: 0x06014E45 RID: 85573 RVA: 0x0064B316 File Offset: 0x00649716
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node38()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06014E46 RID: 85574 RVA: 0x0064B32C File Offset: 0x0064972C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E72C RID: 59180
		private float opl_p0;
	}
}
