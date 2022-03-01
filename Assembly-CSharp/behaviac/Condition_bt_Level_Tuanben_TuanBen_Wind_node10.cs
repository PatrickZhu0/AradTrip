using System;

namespace behaviac
{
	// Token: 0x02002AF9 RID: 11001
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node10 : Condition
	{
		// Token: 0x06013F06 RID: 81670 RVA: 0x005FC2F3 File Offset: 0x005FA6F3
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node10()
		{
			this.opl_p0 = 450;
		}

		// Token: 0x06013F07 RID: 81671 RVA: 0x005FC308 File Offset: 0x005FA708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D958 RID: 55640
		private int opl_p0;
	}
}
