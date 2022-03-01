using System;

namespace behaviac
{
	// Token: 0x0200330D RID: 13069
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node0 : Condition
	{
		// Token: 0x06014E83 RID: 85635 RVA: 0x0064CB27 File Offset: 0x0064AF27
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node0()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014E84 RID: 85636 RVA: 0x0064CB3C File Offset: 0x0064AF3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E76E RID: 59246
		private float opl_p0;
	}
}
