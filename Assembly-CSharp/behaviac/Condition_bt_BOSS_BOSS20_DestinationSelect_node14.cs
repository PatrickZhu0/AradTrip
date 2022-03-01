using System;

namespace behaviac
{
	// Token: 0x020029FF RID: 10751
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node14 : Condition
	{
		// Token: 0x06013D30 RID: 81200 RVA: 0x005EF265 File Offset: 0x005ED665
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013D31 RID: 81201 RVA: 0x005EF278 File Offset: 0x005ED678
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A3 RID: 55203
		private float opl_p0;
	}
}
