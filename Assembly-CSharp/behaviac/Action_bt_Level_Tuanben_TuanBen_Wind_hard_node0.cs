using System;

namespace behaviac
{
	// Token: 0x02002B18 RID: 11032
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node0 : Action
	{
		// Token: 0x06013F42 RID: 81730 RVA: 0x005FD5E3 File Offset: 0x005FB9E3
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = 0;
		}

		// Token: 0x06013F43 RID: 81731 RVA: 0x005FD600 File Offset: 0x005FBA00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D983 RID: 55683
		private LevelCounterType method_p0;

		// Token: 0x0400D984 RID: 55684
		private int method_p1;
	}
}
