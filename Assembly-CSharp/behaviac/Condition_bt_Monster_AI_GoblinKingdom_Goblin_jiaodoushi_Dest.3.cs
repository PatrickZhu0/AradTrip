using System;

namespace behaviac
{
	// Token: 0x02003335 RID: 13109
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node4 : Condition
	{
		// Token: 0x06014ECE RID: 85710 RVA: 0x0064E18C File Offset: 0x0064C58C
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node4()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06014ECF RID: 85711 RVA: 0x0064E1A0 File Offset: 0x0064C5A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7B6 RID: 59318
		private float opl_p0;
	}
}
