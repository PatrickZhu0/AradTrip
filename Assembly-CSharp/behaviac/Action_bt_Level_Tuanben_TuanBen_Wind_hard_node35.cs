using System;

namespace behaviac
{
	// Token: 0x02002B13 RID: 11027
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node35 : Action
	{
		// Token: 0x06013F38 RID: 81720 RVA: 0x005FD4AB File Offset: 0x005FB8AB
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06013F39 RID: 81721 RVA: 0x005FD4C1 File Offset: 0x005FB8C1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCountTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D97B RID: 55675
		private int method_p0;
	}
}
