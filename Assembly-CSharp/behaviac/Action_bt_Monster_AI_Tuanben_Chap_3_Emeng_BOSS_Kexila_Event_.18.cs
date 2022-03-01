using System;

namespace behaviac
{
	// Token: 0x020038B7 RID: 14519
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node65 : Action
	{
		// Token: 0x0601594D RID: 88397 RVA: 0x00683D23 File Offset: 0x00682123
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node65()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得超级强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x0601594E RID: 88398 RVA: 0x00683D4F File Offset: 0x0068214F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2F4 RID: 62196
		private string method_p0;

		// Token: 0x0400F2F5 RID: 62197
		private float method_p1;

		// Token: 0x0400F2F6 RID: 62198
		private int method_p2;
	}
}
