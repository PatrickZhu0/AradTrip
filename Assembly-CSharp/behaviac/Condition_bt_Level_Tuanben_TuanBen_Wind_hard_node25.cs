using System;

namespace behaviac
{
	// Token: 0x02002B21 RID: 11041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node25 : Condition
	{
		// Token: 0x06013F54 RID: 81748 RVA: 0x005FD892 File Offset: 0x005FBC92
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node25()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 0;
		}

		// Token: 0x06013F55 RID: 81749 RVA: 0x005FD8A8 File Offset: 0x005FBCA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D990 RID: 55696
		private LevelCounterType opl_p0;

		// Token: 0x0400D991 RID: 55697
		private int opl_p1;
	}
}
