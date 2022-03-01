using System;

namespace behaviac
{
	// Token: 0x0200330F RID: 13071
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node6 : Action
	{
		// Token: 0x06014E87 RID: 85639 RVA: 0x0064CBD6 File Offset: 0x0064AFD6
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "下手真狠，溜了溜了！";
			this.method_p1 = 3f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E88 RID: 85640 RVA: 0x0064CC02 File Offset: 0x0064B002
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E774 RID: 59252
		private string method_p0;

		// Token: 0x0400E775 RID: 59253
		private float method_p1;

		// Token: 0x0400E776 RID: 59254
		private int method_p2;
	}
}
