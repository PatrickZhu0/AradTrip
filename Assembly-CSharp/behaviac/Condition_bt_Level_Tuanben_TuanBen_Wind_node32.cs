using System;

namespace behaviac
{
	// Token: 0x02002B0A RID: 11018
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node32 : Condition
	{
		// Token: 0x06013F28 RID: 81704 RVA: 0x005FC899 File Offset: 0x005FAC99
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node32()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F29 RID: 81705 RVA: 0x005FC8AC File Offset: 0x005FACAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D974 RID: 55668
		private int opl_p0;
	}
}
