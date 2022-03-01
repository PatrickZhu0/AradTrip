using System;

namespace behaviac
{
	// Token: 0x0200307F RID: 12415
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node17 : Condition
	{
		// Token: 0x060149C3 RID: 84419 RVA: 0x0063487F File Offset: 0x00632C7F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060149C4 RID: 84420 RVA: 0x00634894 File Offset: 0x00632C94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E320 RID: 58144
		private float opl_p0;
	}
}
