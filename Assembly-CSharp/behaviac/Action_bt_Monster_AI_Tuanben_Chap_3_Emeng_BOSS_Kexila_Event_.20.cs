using System;

namespace behaviac
{
	// Token: 0x020038BB RID: 14523
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node45 : Action
	{
		// Token: 0x06015955 RID: 88405 RVA: 0x00683E56 File Offset: 0x00682256
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node45()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x06015956 RID: 88406 RVA: 0x00683E77 File Offset: 0x00682277
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2FD RID: 62205
		private BE_Target method_p0;

		// Token: 0x0400F2FE RID: 62206
		private int method_p1;
	}
}
