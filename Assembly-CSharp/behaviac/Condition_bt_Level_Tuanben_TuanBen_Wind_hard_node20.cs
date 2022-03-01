using System;

namespace behaviac
{
	// Token: 0x02002B1F RID: 11039
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node20 : Condition
	{
		// Token: 0x06013F50 RID: 81744 RVA: 0x005FD7B1 File Offset: 0x005FBBB1
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node20()
		{
			this.opl_p0 = 600;
		}

		// Token: 0x06013F51 RID: 81745 RVA: 0x005FD7C4 File Offset: 0x005FBBC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D98C RID: 55692
		private int opl_p0;
	}
}
