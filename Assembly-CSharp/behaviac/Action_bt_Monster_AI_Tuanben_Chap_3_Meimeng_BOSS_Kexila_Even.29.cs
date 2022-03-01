using System;

namespace behaviac
{
	// Token: 0x0200397B RID: 14715
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node29 : Action
	{
		// Token: 0x06015ACD RID: 88781 RVA: 0x0068B98E File Offset: 0x00689D8E
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015ACE RID: 88782 RVA: 0x0068B9A4 File Offset: 0x00689DA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F476 RID: 62582
		private int method_p0;
	}
}
