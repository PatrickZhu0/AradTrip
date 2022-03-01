using System;

namespace behaviac
{
	// Token: 0x020029FD RID: 10749
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node11 : Condition
	{
		// Token: 0x06013D2C RID: 81196 RVA: 0x005EF1F5 File Offset: 0x005ED5F5
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node11()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013D2D RID: 81197 RVA: 0x005EF208 File Offset: 0x005ED608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A1 RID: 55201
		private float opl_p0;
	}
}
