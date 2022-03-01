using System;

namespace behaviac
{
	// Token: 0x020032E1 RID: 13025
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node31 : Action
	{
		// Token: 0x06014E30 RID: 85552 RVA: 0x0064AFC3 File Offset: 0x006493C3
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "快关门...有老鼠钻进来了！别让他咬我的脚！";
			this.method_p1 = 5f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E31 RID: 85553 RVA: 0x0064AFEF File Offset: 0x006493EF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E710 RID: 59152
		private string method_p0;

		// Token: 0x0400E711 RID: 59153
		private float method_p1;

		// Token: 0x0400E712 RID: 59154
		private int method_p2;
	}
}
