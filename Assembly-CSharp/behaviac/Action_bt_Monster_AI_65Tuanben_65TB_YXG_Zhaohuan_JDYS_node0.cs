using System;

namespace behaviac
{
	// Token: 0x02002D3B RID: 11579
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node0 : Action
	{
		// Token: 0x0601435B RID: 82779 RVA: 0x006123E3 File Offset: 0x006107E3
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node0()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 0;
		}

		// Token: 0x0601435C RID: 82780 RVA: 0x00612404 File Offset: 0x00610804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD1D RID: 56605
		private int method_p0;

		// Token: 0x0400DD1E RID: 56606
		private int method_p1;
	}
}
