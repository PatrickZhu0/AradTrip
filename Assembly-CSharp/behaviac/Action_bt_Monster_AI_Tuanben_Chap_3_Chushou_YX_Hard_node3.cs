using System;

namespace behaviac
{
	// Token: 0x02003831 RID: 14385
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3 : Action
	{
		// Token: 0x0601584B RID: 88139 RVA: 0x0067E97A File Offset: 0x0067CD7A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 0;
		}

		// Token: 0x0601584C RID: 88140 RVA: 0x0067E99C File Offset: 0x0067CD9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F20E RID: 61966
		private int method_p0;

		// Token: 0x0400F20F RID: 61967
		private int method_p1;
	}
}
