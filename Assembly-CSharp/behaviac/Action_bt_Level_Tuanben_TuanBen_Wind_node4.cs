using System;

namespace behaviac
{
	// Token: 0x02002AF6 RID: 10998
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node4 : Action
	{
		// Token: 0x06013F00 RID: 81664 RVA: 0x005FC22D File Offset: 0x005FA62D
		public Action_bt_Level_Tuanben_TuanBen_Wind_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 547797;
			this.method_p1 = true;
		}

		// Token: 0x06013F01 RID: 81665 RVA: 0x005FC24E File Offset: 0x005FA64E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_AllPlayersAddBuffInfo(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D952 RID: 55634
		private int method_p0;

		// Token: 0x0400D953 RID: 55635
		private bool method_p1;
	}
}
