using System;

namespace behaviac
{
	// Token: 0x02003BD1 RID: 15313
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node65 : Action
	{
		// Token: 0x06015F4F RID: 89935 RVA: 0x006A29D7 File Offset: 0x006A0DD7
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node65()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得超级强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015F50 RID: 89936 RVA: 0x006A2A03 File Offset: 0x006A0E03
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7E8 RID: 63464
		private string method_p0;

		// Token: 0x0400F7E9 RID: 63465
		private float method_p1;

		// Token: 0x0400F7EA RID: 63466
		private int method_p2;
	}
}
