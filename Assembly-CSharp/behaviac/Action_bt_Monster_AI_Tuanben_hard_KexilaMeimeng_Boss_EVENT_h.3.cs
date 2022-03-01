using System;

namespace behaviac
{
	// Token: 0x02003C56 RID: 15446
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node7 : Action
	{
		// Token: 0x06016054 RID: 90196 RVA: 0x006A7D25 File Offset: 0x006A6125
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016055 RID: 90197 RVA: 0x006A7D51 File Offset: 0x006A6151
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8CD RID: 63693
		private string method_p0;

		// Token: 0x0400F8CE RID: 63694
		private float method_p1;

		// Token: 0x0400F8CF RID: 63695
		private int method_p2;
	}
}
