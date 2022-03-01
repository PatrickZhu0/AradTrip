using System;

namespace behaviac
{
	// Token: 0x020029F9 RID: 10745
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node3 : Condition
	{
		// Token: 0x06013D24 RID: 81188 RVA: 0x005EF08B File Offset: 0x005ED48B
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node3()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013D25 RID: 81189 RVA: 0x005EF0A0 File Offset: 0x005ED4A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D797 RID: 55191
		private float opl_p0;
	}
}
