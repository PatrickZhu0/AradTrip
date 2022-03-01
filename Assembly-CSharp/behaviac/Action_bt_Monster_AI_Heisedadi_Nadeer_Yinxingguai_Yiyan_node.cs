using System;

namespace behaviac
{
	// Token: 0x0200354E RID: 13646
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node105 : Action
	{
		// Token: 0x060152DC RID: 86748 RVA: 0x00662227 File Offset: 0x00660627
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node105()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "我们…还会…再见的……就在……";
			this.method_p1 = 5f;
			this.method_p2 = 0;
		}

		// Token: 0x060152DD RID: 86749 RVA: 0x00662253 File Offset: 0x00660653
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC93 RID: 60563
		private string method_p0;

		// Token: 0x0400EC94 RID: 60564
		private float method_p1;

		// Token: 0x0400EC95 RID: 60565
		private int method_p2;
	}
}
