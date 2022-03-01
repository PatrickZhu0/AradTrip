using System;

namespace behaviac
{
	// Token: 0x020038B0 RID: 14512
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node64 : Action
	{
		// Token: 0x0601593F RID: 88383 RVA: 0x00683AE9 File Offset: 0x00681EE9
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node64()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015940 RID: 88384 RVA: 0x00683B15 File Offset: 0x00681F15
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2DF RID: 62175
		private string method_p0;

		// Token: 0x0400F2E0 RID: 62176
		private float method_p1;

		// Token: 0x0400F2E1 RID: 62177
		private int method_p2;
	}
}
