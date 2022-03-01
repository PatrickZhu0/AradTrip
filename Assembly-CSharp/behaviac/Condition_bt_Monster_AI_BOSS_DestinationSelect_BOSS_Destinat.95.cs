using System;

namespace behaviac
{
	// Token: 0x02003042 RID: 12354
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node5 : Condition
	{
		// Token: 0x0601494B RID: 84299 RVA: 0x00632520 File Offset: 0x00630920
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601494C RID: 84300 RVA: 0x00632534 File Offset: 0x00630934
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2A9 RID: 58025
		private float opl_p0;
	}
}
