using System;

namespace behaviac
{
	// Token: 0x0200333B RID: 13115
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node12 : Condition
	{
		// Token: 0x06014EDA RID: 85722 RVA: 0x0064E369 File Offset: 0x0064C769
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node12()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014EDB RID: 85723 RVA: 0x0064E37C File Offset: 0x0064C77C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7C2 RID: 59330
		private float opl_p0;
	}
}
