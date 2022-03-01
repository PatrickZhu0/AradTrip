using System;

namespace behaviac
{
	// Token: 0x02003C5D RID: 15453
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node8 : Action
	{
		// Token: 0x06016062 RID: 90210 RVA: 0x006A7F5F File Offset: 0x006A635F
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得超级强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016063 RID: 90211 RVA: 0x006A7F8B File Offset: 0x006A638B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8E2 RID: 63714
		private string method_p0;

		// Token: 0x0400F8E3 RID: 63715
		private float method_p1;

		// Token: 0x0400F8E4 RID: 63716
		private int method_p2;
	}
}
