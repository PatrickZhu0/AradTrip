using System;

namespace behaviac
{
	// Token: 0x020038B6 RID: 14518
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node56 : Action
	{
		// Token: 0x0601594B RID: 88395 RVA: 0x00683CE8 File Offset: 0x006820E8
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node56()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x0601594C RID: 88396 RVA: 0x00683D09 File Offset: 0x00682109
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2F2 RID: 62194
		private BE_Target method_p0;

		// Token: 0x0400F2F3 RID: 62195
		private int method_p1;
	}
}
