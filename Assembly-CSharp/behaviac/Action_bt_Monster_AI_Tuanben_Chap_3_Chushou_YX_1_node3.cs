using System;

namespace behaviac
{
	// Token: 0x0200382D RID: 14381
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_1_node3 : Action
	{
		// Token: 0x06015844 RID: 88132 RVA: 0x0067E78A File Offset: 0x0067CB8A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_1_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 180000;
			this.method_p1 = 0;
		}

		// Token: 0x06015845 RID: 88133 RVA: 0x0067E7AC File Offset: 0x0067CBAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F205 RID: 61957
		private int method_p0;

		// Token: 0x0400F206 RID: 61958
		private int method_p1;
	}
}
