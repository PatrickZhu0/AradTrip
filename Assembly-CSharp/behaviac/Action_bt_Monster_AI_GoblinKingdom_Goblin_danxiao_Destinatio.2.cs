using System;

namespace behaviac
{
	// Token: 0x020032FC RID: 13052
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node23 : Action
	{
		// Token: 0x06014E62 RID: 85602 RVA: 0x0064C13B File Offset: 0x0064A53B
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "离我远点，不要过来哦！";
			this.method_p1 = 2f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E63 RID: 85603 RVA: 0x0064C167 File Offset: 0x0064A567
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E74F RID: 59215
		private string method_p0;

		// Token: 0x0400E750 RID: 59216
		private float method_p1;

		// Token: 0x0400E751 RID: 59217
		private int method_p2;
	}
}
