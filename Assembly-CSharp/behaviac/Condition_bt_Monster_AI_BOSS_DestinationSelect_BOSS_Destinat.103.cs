using System;

namespace behaviac
{
	// Token: 0x0200304E RID: 12366
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node21 : Condition
	{
		// Token: 0x06014963 RID: 84323 RVA: 0x006328CF File Offset: 0x00630CCF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node21()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014964 RID: 84324 RVA: 0x006328E4 File Offset: 0x00630CE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2C1 RID: 58049
		private float opl_p0;
	}
}
