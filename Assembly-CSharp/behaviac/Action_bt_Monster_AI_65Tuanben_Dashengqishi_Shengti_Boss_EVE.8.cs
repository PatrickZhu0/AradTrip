using System;

namespace behaviac
{
	// Token: 0x02002E95 RID: 11925
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node18 : Action
	{
		// Token: 0x06014605 RID: 83461 RVA: 0x00620C12 File Offset: 0x0061F012
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "卡德蒙进入圣体阶段，祭台将关闭！";
			this.method_p1 = 7f;
			this.method_p2 = 2;
		}

		// Token: 0x06014606 RID: 83462 RVA: 0x00620C3E File Offset: 0x0061F03E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF86 RID: 57222
		private string method_p0;

		// Token: 0x0400DF87 RID: 57223
		private float method_p1;

		// Token: 0x0400DF88 RID: 57224
		private int method_p2;
	}
}
