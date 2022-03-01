using System;

namespace behaviac
{
	// Token: 0x020038CF RID: 14543
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node21 : Action
	{
		// Token: 0x0601597D RID: 88445 RVA: 0x0068458A File Offset: 0x0068298A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521642;
		}

		// Token: 0x0601597E RID: 88446 RVA: 0x006845AB File Offset: 0x006829AB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F337 RID: 62263
		private BE_Target method_p0;

		// Token: 0x0400F338 RID: 62264
		private int method_p1;
	}
}
