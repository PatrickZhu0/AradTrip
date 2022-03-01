using System;

namespace behaviac
{
	// Token: 0x02002B14 RID: 11028
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node4 : Action
	{
		// Token: 0x06013F3A RID: 81722 RVA: 0x005FD4D5 File Offset: 0x005FB8D5
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 547797;
			this.method_p1 = true;
		}

		// Token: 0x06013F3B RID: 81723 RVA: 0x005FD4F6 File Offset: 0x005FB8F6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_AllPlayersAddBuffInfo(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D97C RID: 55676
		private int method_p0;

		// Token: 0x0400D97D RID: 55677
		private bool method_p1;
	}
}
