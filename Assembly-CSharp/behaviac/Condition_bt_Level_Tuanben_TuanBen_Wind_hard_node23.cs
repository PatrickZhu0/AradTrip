using System;

namespace behaviac
{
	// Token: 0x02002B1D RID: 11037
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node23 : Condition
	{
		// Token: 0x06013F4C RID: 81740 RVA: 0x005FD718 File Offset: 0x005FBB18
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node23()
		{
			this.opl_p0 = 85140021;
		}

		// Token: 0x06013F4D RID: 81741 RVA: 0x005FD72C File Offset: 0x005FBB2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_HaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D989 RID: 55689
		private int opl_p0;
	}
}
