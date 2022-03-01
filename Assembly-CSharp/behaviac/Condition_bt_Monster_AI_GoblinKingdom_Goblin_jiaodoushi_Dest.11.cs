using System;

namespace behaviac
{
	// Token: 0x02003342 RID: 13122
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node28 : Condition
	{
		// Token: 0x06014EE8 RID: 85736 RVA: 0x0064E535 File Offset: 0x0064C935
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node28()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014EE9 RID: 85737 RVA: 0x0064E548 File Offset: 0x0064C948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7CC RID: 59340
		private float opl_p0;
	}
}
