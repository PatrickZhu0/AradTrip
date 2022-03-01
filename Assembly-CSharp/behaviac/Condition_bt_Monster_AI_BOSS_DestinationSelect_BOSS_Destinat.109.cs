using System;

namespace behaviac
{
	// Token: 0x02003057 RID: 12375
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node33 : Condition
	{
		// Token: 0x06014975 RID: 84341 RVA: 0x00632B93 File Offset: 0x00630F93
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node33()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06014976 RID: 84342 RVA: 0x00632BA8 File Offset: 0x00630FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2D3 RID: 58067
		private float opl_p0;
	}
}
