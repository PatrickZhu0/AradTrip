using System;

namespace behaviac
{
	// Token: 0x02002B07 RID: 11015
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node28 : Condition
	{
		// Token: 0x06013F22 RID: 81698 RVA: 0x005FC769 File Offset: 0x005FAB69
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node28()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F23 RID: 81699 RVA: 0x005FC77C File Offset: 0x005FAB7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D96E RID: 55662
		private int opl_p0;
	}
}
