using System;

namespace behaviac
{
	// Token: 0x02002B28 RID: 11048
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node32 : Condition
	{
		// Token: 0x06013F62 RID: 81762 RVA: 0x005FDB41 File Offset: 0x005FBF41
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node32()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F63 RID: 81763 RVA: 0x005FDB54 File Offset: 0x005FBF54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D99E RID: 55710
		private int opl_p0;
	}
}
