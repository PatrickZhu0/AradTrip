using System;

namespace behaviac
{
	// Token: 0x020038BC RID: 14524
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node66 : Action
	{
		// Token: 0x06015957 RID: 88407 RVA: 0x00683E91 File Offset: 0x00682291
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node66()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015958 RID: 88408 RVA: 0x00683EBD File Offset: 0x006822BD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2FF RID: 62207
		private string method_p0;

		// Token: 0x0400F300 RID: 62208
		private float method_p1;

		// Token: 0x0400F301 RID: 62209
		private int method_p2;
	}
}
