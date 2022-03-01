using System;

namespace behaviac
{
	// Token: 0x020038C8 RID: 14536
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node16 : Action
	{
		// Token: 0x0601596F RID: 88431 RVA: 0x006842CE File Offset: 0x006826CE
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521642;
		}

		// Token: 0x06015970 RID: 88432 RVA: 0x006842EF File Offset: 0x006826EF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F321 RID: 62241
		private BE_Target method_p0;

		// Token: 0x0400F322 RID: 62242
		private int method_p1;
	}
}
