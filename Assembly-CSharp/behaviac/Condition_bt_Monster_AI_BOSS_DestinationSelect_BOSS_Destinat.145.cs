using System;

namespace behaviac
{
	// Token: 0x02003091 RID: 12433
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node5 : Condition
	{
		// Token: 0x060149E6 RID: 84454 RVA: 0x006356B4 File Offset: 0x00633AB4
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node5()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060149E7 RID: 84455 RVA: 0x006356C8 File Offset: 0x00633AC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E343 RID: 58179
		private float opl_p0;
	}
}
