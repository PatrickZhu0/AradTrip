using System;

namespace behaviac
{
	// Token: 0x02002A04 RID: 10756
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node24 : Condition
	{
		// Token: 0x06013D3A RID: 81210 RVA: 0x005EF371 File Offset: 0x005ED771
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node24()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06013D3B RID: 81211 RVA: 0x005EF384 File Offset: 0x005ED784
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A8 RID: 55208
		private float opl_p0;
	}
}
