using System;

namespace behaviac
{
	// Token: 0x02003975 RID: 14709
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node4 : Action
	{
		// Token: 0x06015AC1 RID: 88769 RVA: 0x0068B762 File Offset: 0x00689B62
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521677;
		}

		// Token: 0x06015AC2 RID: 88770 RVA: 0x0068B783 File Offset: 0x00689B83
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F469 RID: 62569
		private BE_Target method_p0;

		// Token: 0x0400F46A RID: 62570
		private int method_p1;
	}
}
