using System;

namespace behaviac
{
	// Token: 0x020031E2 RID: 12770
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_YX_Zhaohuan_Shiyachong_node2 : Action
	{
		// Token: 0x06014C52 RID: 85074 RVA: 0x00641E3D File Offset: 0x0064023D
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_YX_Zhaohuan_Shiyachong_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 15000;
			this.method_p1 = 0;
		}

		// Token: 0x06014C53 RID: 85075 RVA: 0x00641E60 File Offset: 0x00640260
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E5AD RID: 58797
		private int method_p0;

		// Token: 0x0400E5AE RID: 58798
		private int method_p1;
	}
}
