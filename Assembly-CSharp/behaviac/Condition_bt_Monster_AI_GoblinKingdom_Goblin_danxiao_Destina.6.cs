using System;

namespace behaviac
{
	// Token: 0x020032FF RID: 13055
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node7 : Condition
	{
		// Token: 0x06014E68 RID: 85608 RVA: 0x0064C230 File Offset: 0x0064A630
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node7()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06014E69 RID: 85609 RVA: 0x0064C244 File Offset: 0x0064A644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E757 RID: 59223
		private float opl_p0;
	}
}
