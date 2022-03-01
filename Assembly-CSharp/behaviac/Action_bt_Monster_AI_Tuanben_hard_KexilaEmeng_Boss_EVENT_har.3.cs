using System;

namespace behaviac
{
	// Token: 0x02003BCA RID: 15306
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node64 : Action
	{
		// Token: 0x06015F41 RID: 89921 RVA: 0x006A279D File Offset: 0x006A0B9D
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node64()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015F42 RID: 89922 RVA: 0x006A27C9 File Offset: 0x006A0BC9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7D3 RID: 63443
		private string method_p0;

		// Token: 0x0400F7D4 RID: 63444
		private float method_p1;

		// Token: 0x0400F7D5 RID: 63445
		private int method_p2;
	}
}
