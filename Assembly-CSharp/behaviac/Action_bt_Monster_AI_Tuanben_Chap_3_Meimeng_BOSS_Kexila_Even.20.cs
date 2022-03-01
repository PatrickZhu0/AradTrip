using System;

namespace behaviac
{
	// Token: 0x02003969 RID: 14697
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node66 : Action
	{
		// Token: 0x06015AA9 RID: 88745 RVA: 0x0068B365 File Offset: 0x00689765
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node66()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015AAA RID: 88746 RVA: 0x0068B391 File Offset: 0x00689791
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F44D RID: 62541
		private string method_p0;

		// Token: 0x0400F44E RID: 62542
		private float method_p1;

		// Token: 0x0400F44F RID: 62543
		private int method_p2;
	}
}
