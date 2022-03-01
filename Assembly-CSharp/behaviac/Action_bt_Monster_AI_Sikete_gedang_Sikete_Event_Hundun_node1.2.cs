using System;

namespace behaviac
{
	// Token: 0x0200373E RID: 14142
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node14 : Action
	{
		// Token: 0x06015687 RID: 87687 RVA: 0x0067569F File Offset: 0x00673A9F
		public Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06015688 RID: 87688 RVA: 0x006756C0 File Offset: 0x00673AC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F057 RID: 61527
		private BE_Target method_p0;

		// Token: 0x0400F058 RID: 61528
		private int method_p1;
	}
}
