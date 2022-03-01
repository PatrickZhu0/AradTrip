using System;

namespace behaviac
{
	// Token: 0x02003989 RID: 14729
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node32 : Action
	{
		// Token: 0x06015AE9 RID: 88809 RVA: 0x0068BD02 File Offset: 0x0068A102
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node32()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015AEA RID: 88810 RVA: 0x0068BD18 File Offset: 0x0068A118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F489 RID: 62601
		private int method_p0;
	}
}
