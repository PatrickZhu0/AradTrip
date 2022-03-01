using System;

namespace behaviac
{
	// Token: 0x02003CBF RID: 15551
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node7 : Action
	{
		// Token: 0x06016120 RID: 90400 RVA: 0x006AC2D9 File Offset: 0x006AA6D9
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016121 RID: 90401 RVA: 0x006AC305 File Offset: 0x006AA705
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9C8 RID: 63944
		private string method_p0;

		// Token: 0x0400F9C9 RID: 63945
		private float method_p1;

		// Token: 0x0400F9CA RID: 63946
		private int method_p2;
	}
}
