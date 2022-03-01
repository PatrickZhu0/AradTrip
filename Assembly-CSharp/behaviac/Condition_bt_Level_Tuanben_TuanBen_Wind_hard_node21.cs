using System;

namespace behaviac
{
	// Token: 0x02002B22 RID: 11042
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node21 : Condition
	{
		// Token: 0x06013F56 RID: 81750 RVA: 0x005FD8E1 File Offset: 0x005FBCE1
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node21()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F57 RID: 81751 RVA: 0x005FD8F4 File Offset: 0x005FBCF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D992 RID: 55698
		private int opl_p0;
	}
}
