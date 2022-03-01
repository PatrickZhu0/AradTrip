using System;

namespace behaviac
{
	// Token: 0x02003BD6 RID: 15318
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node66 : Action
	{
		// Token: 0x06015F59 RID: 89945 RVA: 0x006A2B45 File Offset: 0x006A0F45
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node66()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015F5A RID: 89946 RVA: 0x006A2B71 File Offset: 0x006A0F71
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7F3 RID: 63475
		private string method_p0;

		// Token: 0x0400F7F4 RID: 63476
		private float method_p1;

		// Token: 0x0400F7F5 RID: 63477
		private int method_p2;
	}
}
