using System;

namespace behaviac
{
	// Token: 0x0200398F RID: 14735
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node11 : Action
	{
		// Token: 0x06015AF3 RID: 88819 RVA: 0x0068CC7A File Offset: 0x0068B07A
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "看看我发现了什么宝贝！";
			this.method_p1 = 1f;
			this.method_p2 = 0;
		}

		// Token: 0x06015AF4 RID: 88820 RVA: 0x0068CCA6 File Offset: 0x0068B0A6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F48E RID: 62606
		private string method_p0;

		// Token: 0x0400F48F RID: 62607
		private float method_p1;

		// Token: 0x0400F490 RID: 62608
		private int method_p2;
	}
}
