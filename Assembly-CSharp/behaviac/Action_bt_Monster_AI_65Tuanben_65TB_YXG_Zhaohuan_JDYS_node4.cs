using System;

namespace behaviac
{
	// Token: 0x02002D43 RID: 11587
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4 : Action
	{
		// Token: 0x0601436B RID: 82795 RVA: 0x006125DB File Offset: 0x006109DB
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 2;
		}

		// Token: 0x0601436C RID: 82796 RVA: 0x006125FC File Offset: 0x006109FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD2F RID: 56623
		private int method_p0;

		// Token: 0x0400DD30 RID: 56624
		private int method_p1;
	}
}
