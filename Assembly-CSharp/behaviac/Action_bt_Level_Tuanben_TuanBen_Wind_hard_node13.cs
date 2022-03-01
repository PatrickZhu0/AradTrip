using System;

namespace behaviac
{
	// Token: 0x02002B1A RID: 11034
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node13 : Action
	{
		// Token: 0x06013F46 RID: 81734 RVA: 0x005FD663 File Offset: 0x005FBA63
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = 1;
		}

		// Token: 0x06013F47 RID: 81735 RVA: 0x005FD680 File Offset: 0x005FBA80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D986 RID: 55686
		private LevelCounterType method_p0;

		// Token: 0x0400D987 RID: 55687
		private int method_p1;
	}
}
