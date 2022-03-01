using System;

namespace behaviac
{
	// Token: 0x020038BA RID: 14522
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node41 : Action
	{
		// Token: 0x06015953 RID: 88403 RVA: 0x00683E1B File Offset: 0x0068221B
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570215;
		}

		// Token: 0x06015954 RID: 88404 RVA: 0x00683E3C File Offset: 0x0068223C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2FB RID: 62203
		private BE_Target method_p0;

		// Token: 0x0400F2FC RID: 62204
		private int method_p1;
	}
}
