using System;

namespace behaviac
{
	// Token: 0x02002B04 RID: 11012
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node21 : Condition
	{
		// Token: 0x06013F1C RID: 81692 RVA: 0x005FC639 File Offset: 0x005FAA39
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node21()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F1D RID: 81693 RVA: 0x005FC64C File Offset: 0x005FAA4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D968 RID: 55656
		private int opl_p0;
	}
}
