using System;

namespace behaviac
{
	// Token: 0x020032FB RID: 13051
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node5 : Condition
	{
		// Token: 0x06014E60 RID: 85600 RVA: 0x0064C0F5 File Offset: 0x0064A4F5
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node5()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06014E61 RID: 85601 RVA: 0x0064C108 File Offset: 0x0064A508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E74E RID: 59214
		private float opl_p0;
	}
}
