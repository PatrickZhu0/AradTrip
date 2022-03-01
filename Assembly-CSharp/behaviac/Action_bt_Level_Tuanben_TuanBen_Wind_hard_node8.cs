using System;

namespace behaviac
{
	// Token: 0x02002B16 RID: 11030
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node8 : Action
	{
		// Token: 0x06013F3E RID: 81726 RVA: 0x005FD564 File Offset: 0x005FB964
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = -1;
		}

		// Token: 0x06013F3F RID: 81727 RVA: 0x005FD581 File Offset: 0x005FB981
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D980 RID: 55680
		private LevelCounterType method_p0;

		// Token: 0x0400D981 RID: 55681
		private int method_p1;
	}
}
