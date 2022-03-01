using System;

namespace behaviac
{
	// Token: 0x0200333D RID: 13117
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node7 : Condition
	{
		// Token: 0x06014EDE RID: 85726 RVA: 0x0064E3D9 File Offset: 0x0064C7D9
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node7()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014EDF RID: 85727 RVA: 0x0064E3EC File Offset: 0x0064C7EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7C4 RID: 59332
		private float opl_p0;
	}
}
