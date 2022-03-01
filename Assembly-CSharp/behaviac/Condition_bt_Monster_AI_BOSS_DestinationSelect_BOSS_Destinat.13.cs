using System;

namespace behaviac
{
	// Token: 0x02002FBE RID: 12222
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node29 : Condition
	{
		// Token: 0x06014849 RID: 84041 RVA: 0x0062CC27 File Offset: 0x0062B027
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node29()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601484A RID: 84042 RVA: 0x0062CC3C File Offset: 0x0062B03C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1A7 RID: 57767
		private float opl_p0;
	}
}
