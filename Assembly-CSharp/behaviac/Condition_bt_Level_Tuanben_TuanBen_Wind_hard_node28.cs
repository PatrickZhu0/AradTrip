using System;

namespace behaviac
{
	// Token: 0x02002B25 RID: 11045
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node28 : Condition
	{
		// Token: 0x06013F5C RID: 81756 RVA: 0x005FDA11 File Offset: 0x005FBE11
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node28()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F5D RID: 81757 RVA: 0x005FDA24 File Offset: 0x005FBE24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D998 RID: 55704
		private int opl_p0;
	}
}
