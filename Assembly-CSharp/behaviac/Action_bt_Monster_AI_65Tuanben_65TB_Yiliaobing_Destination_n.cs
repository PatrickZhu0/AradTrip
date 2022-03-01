using System;

namespace behaviac
{
	// Token: 0x02002D18 RID: 11544
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node23 : Action
	{
		// Token: 0x0601431D RID: 82717 RVA: 0x00611219 File Offset: 0x0060F619
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "你不要过来啊！";
			this.method_p1 = 3f;
			this.method_p2 = 0;
		}

		// Token: 0x0601431E RID: 82718 RVA: 0x00611245 File Offset: 0x0060F645
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCD1 RID: 56529
		private string method_p0;

		// Token: 0x0400DCD2 RID: 56530
		private float method_p1;

		// Token: 0x0400DCD3 RID: 56531
		private int method_p2;
	}
}
