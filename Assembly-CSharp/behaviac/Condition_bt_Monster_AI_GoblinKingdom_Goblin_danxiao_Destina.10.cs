using System;

namespace behaviac
{
	// Token: 0x02003306 RID: 13062
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node14 : Condition
	{
		// Token: 0x06014E76 RID: 85622 RVA: 0x0064C455 File Offset: 0x0064A855
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014E77 RID: 85623 RVA: 0x0064C468 File Offset: 0x0064A868
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E766 RID: 59238
		private float opl_p0;
	}
}
