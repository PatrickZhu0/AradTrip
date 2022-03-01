using System;

namespace behaviac
{
	// Token: 0x02002FEE RID: 12270
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node29 : Condition
	{
		// Token: 0x060148A7 RID: 84135 RVA: 0x0062EA6F File Offset: 0x0062CE6F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node29()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060148A8 RID: 84136 RVA: 0x0062EA84 File Offset: 0x0062CE84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E205 RID: 57861
		private float opl_p0;
	}
}
