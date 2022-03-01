using System;

namespace behaviac
{
	// Token: 0x020038A0 RID: 14496
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node16 : Action
	{
		// Token: 0x06015922 RID: 88354 RVA: 0x006831FA File Offset: 0x006815FA
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521642;
		}

		// Token: 0x06015923 RID: 88355 RVA: 0x0068321B File Offset: 0x0068161B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2B8 RID: 62136
		private BE_Target method_p0;

		// Token: 0x0400F2B9 RID: 62137
		private int method_p1;
	}
}
