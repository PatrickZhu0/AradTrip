using System;

namespace behaviac
{
	// Token: 0x02003344 RID: 13124
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node15 : Condition
	{
		// Token: 0x06014EEC RID: 85740 RVA: 0x0064E5A5 File Offset: 0x0064C9A5
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node15()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06014EED RID: 85741 RVA: 0x0064E5B8 File Offset: 0x0064C9B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7CE RID: 59342
		private float opl_p0;
	}
}
