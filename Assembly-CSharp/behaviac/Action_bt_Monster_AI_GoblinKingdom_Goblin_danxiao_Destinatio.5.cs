using System;

namespace behaviac
{
	// Token: 0x02003303 RID: 13059
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node22 : Action
	{
		// Token: 0x06014E70 RID: 85616 RVA: 0x0064C363 File Offset: 0x0064A763
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "你不要过来啊！！";
			this.method_p1 = 2f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E71 RID: 85617 RVA: 0x0064C38F File Offset: 0x0064A78F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E75E RID: 59230
		private string method_p0;

		// Token: 0x0400E75F RID: 59231
		private float method_p1;

		// Token: 0x0400E760 RID: 59232
		private int method_p2;
	}
}
