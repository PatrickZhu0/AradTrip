using System;

namespace behaviac
{
	// Token: 0x02003CC6 RID: 15558
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node8 : Action
	{
		// Token: 0x0601612E RID: 90414 RVA: 0x006AC513 File Offset: 0x006AA913
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得超级强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x0601612F RID: 90415 RVA: 0x006AC53F File Offset: 0x006AA93F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9DD RID: 63965
		private string method_p0;

		// Token: 0x0400F9DE RID: 63966
		private float method_p1;

		// Token: 0x0400F9DF RID: 63967
		private int method_p2;
	}
}
