using System;

namespace behaviac
{
	// Token: 0x02003962 RID: 14690
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node53 : Action
	{
		// Token: 0x06015A9B RID: 88731 RVA: 0x0068B181 File Offset: 0x00689581
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
		}

		// Token: 0x06015A9C RID: 88732 RVA: 0x0068B1A2 File Offset: 0x006895A2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F43E RID: 62526
		private BE_Target method_p0;

		// Token: 0x0400F43F RID: 62527
		private int method_p1;
	}
}
