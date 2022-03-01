using System;

namespace behaviac
{
	// Token: 0x020038C6 RID: 14534
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node3 : Action
	{
		// Token: 0x0601596B RID: 88427 RVA: 0x006841DA File Offset: 0x006825DA
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x0601596C RID: 88428 RVA: 0x006841FC File Offset: 0x006825FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F31D RID: 62237
		private int method_p0;

		// Token: 0x0400F31E RID: 62238
		private int method_p1;
	}
}
