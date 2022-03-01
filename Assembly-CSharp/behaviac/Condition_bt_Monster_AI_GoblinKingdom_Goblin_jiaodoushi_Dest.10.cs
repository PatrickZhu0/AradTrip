using System;

namespace behaviac
{
	// Token: 0x02003340 RID: 13120
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node26 : Condition
	{
		// Token: 0x06014EE4 RID: 85732 RVA: 0x0064E4C5 File Offset: 0x0064C8C5
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node26()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014EE5 RID: 85733 RVA: 0x0064E4D8 File Offset: 0x0064C8D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7CA RID: 59338
		private float opl_p0;
	}
}
