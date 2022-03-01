using System;

namespace behaviac
{
	// Token: 0x02003302 RID: 13058
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node12 : Condition
	{
		// Token: 0x06014E6E RID: 85614 RVA: 0x0064C31D File Offset: 0x0064A71D
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node12()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06014E6F RID: 85615 RVA: 0x0064C330 File Offset: 0x0064A730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E75D RID: 59229
		private float opl_p0;
	}
}
