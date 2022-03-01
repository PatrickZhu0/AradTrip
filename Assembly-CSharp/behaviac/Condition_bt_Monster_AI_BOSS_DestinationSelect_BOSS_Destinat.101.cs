using System;

namespace behaviac
{
	// Token: 0x0200304B RID: 12363
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node17 : Condition
	{
		// Token: 0x0601495D RID: 84317 RVA: 0x006327E3 File Offset: 0x00630BE3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601495E RID: 84318 RVA: 0x006327F8 File Offset: 0x00630BF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2BB RID: 58043
		private float opl_p0;
	}
}
