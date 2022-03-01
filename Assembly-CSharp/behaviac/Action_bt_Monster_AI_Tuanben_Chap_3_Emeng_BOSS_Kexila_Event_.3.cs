using System;

namespace behaviac
{
	// Token: 0x0200389E RID: 14494
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3 : Action
	{
		// Token: 0x0601591E RID: 88350 RVA: 0x00683106 File Offset: 0x00681506
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x0601591F RID: 88351 RVA: 0x00683128 File Offset: 0x00681528
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F2B4 RID: 62132
		private int method_p0;

		// Token: 0x0400F2B5 RID: 62133
		private int method_p1;
	}
}
