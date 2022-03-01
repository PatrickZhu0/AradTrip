using System;

namespace behaviac
{
	// Token: 0x02003954 RID: 14676
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4 : Action
	{
		// Token: 0x06015A82 RID: 88706 RVA: 0x0068AA85 File Offset: 0x00688E85
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521645;
		}

		// Token: 0x06015A83 RID: 88707 RVA: 0x0068AAA6 File Offset: 0x00688EA6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F41C RID: 62492
		private BE_Target method_p0;

		// Token: 0x0400F41D RID: 62493
		private int method_p1;
	}
}
