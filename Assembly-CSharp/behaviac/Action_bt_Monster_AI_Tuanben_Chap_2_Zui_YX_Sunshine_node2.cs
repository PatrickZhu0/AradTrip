using System;

namespace behaviac
{
	// Token: 0x020037E9 RID: 14313
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Sunshine_node2 : Action
	{
		// Token: 0x060157C9 RID: 88009 RVA: 0x0067C428 File Offset: 0x0067A828
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Sunshine_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 0;
		}

		// Token: 0x060157CA RID: 88010 RVA: 0x0067C44C File Offset: 0x0067A84C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F196 RID: 61846
		private int method_p0;

		// Token: 0x0400F197 RID: 61847
		private int method_p1;
	}
}
