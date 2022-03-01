using System;

namespace behaviac
{
	// Token: 0x02002AF4 RID: 10996
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node5 : Condition
	{
		// Token: 0x06013EFC RID: 81660 RVA: 0x005FC1BF File Offset: 0x005FA5BF
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node5()
		{
			this.opl_p0 = 20;
		}

		// Token: 0x06013EFD RID: 81661 RVA: 0x005FC1D0 File Offset: 0x005FA5D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCountTime(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D950 RID: 55632
		private int opl_p0;
	}
}
