using System;

namespace behaviac
{
	// Token: 0x02003060 RID: 12384
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node9 : Condition
	{
		// Token: 0x06014986 RID: 84358 RVA: 0x00633703 File Offset: 0x00631B03
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node9()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06014987 RID: 84359 RVA: 0x00633718 File Offset: 0x00631B18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2E4 RID: 58084
		private float opl_p0;
	}
}
