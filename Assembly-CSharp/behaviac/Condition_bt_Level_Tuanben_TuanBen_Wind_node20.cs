using System;

namespace behaviac
{
	// Token: 0x02002B01 RID: 11009
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node20 : Condition
	{
		// Token: 0x06013F16 RID: 81686 RVA: 0x005FC509 File Offset: 0x005FA909
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node20()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F17 RID: 81687 RVA: 0x005FC51C File Offset: 0x005FA91C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D962 RID: 55650
		private int opl_p0;
	}
}
