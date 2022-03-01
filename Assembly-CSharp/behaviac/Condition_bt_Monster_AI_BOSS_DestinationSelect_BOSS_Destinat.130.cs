using System;

namespace behaviac
{
	// Token: 0x02003079 RID: 12409
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node9 : Condition
	{
		// Token: 0x060149B7 RID: 84407 RVA: 0x006346A7 File Offset: 0x00632AA7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node9()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060149B8 RID: 84408 RVA: 0x006346BC File Offset: 0x00632ABC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E314 RID: 58132
		private float opl_p0;
	}
}
