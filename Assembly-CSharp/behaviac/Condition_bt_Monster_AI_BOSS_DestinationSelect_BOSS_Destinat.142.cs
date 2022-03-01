using System;

namespace behaviac
{
	// Token: 0x0200308B RID: 12427
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node33 : Condition
	{
		// Token: 0x060149DB RID: 84443 RVA: 0x00634C2F File Offset: 0x0063302F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node33()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060149DC RID: 84444 RVA: 0x00634C44 File Offset: 0x00633044
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E338 RID: 58168
		private float opl_p0;
	}
}
