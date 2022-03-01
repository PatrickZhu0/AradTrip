using System;

namespace behaviac
{
	// Token: 0x02002A02 RID: 10754
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node21 : Condition
	{
		// Token: 0x06013D36 RID: 81206 RVA: 0x005EF2FF File Offset: 0x005ED6FF
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node21()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013D37 RID: 81207 RVA: 0x005EF314 File Offset: 0x005ED714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A6 RID: 55206
		private float opl_p0;
	}
}
