using System;

namespace behaviac
{
	// Token: 0x0200371D RID: 14109
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node9 : Action
	{
		// Token: 0x06015647 RID: 87623 RVA: 0x00674407 File Offset: 0x00672807
		public Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06015648 RID: 87624 RVA: 0x00674428 File Offset: 0x00672828
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F014 RID: 61460
		private BE_Target method_p0;

		// Token: 0x0400F015 RID: 61461
		private int method_p1;
	}
}
