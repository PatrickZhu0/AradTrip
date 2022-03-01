using System;

namespace behaviac
{
	// Token: 0x0200345D RID: 13405
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node16 : Action
	{
		// Token: 0x06015106 RID: 86278 RVA: 0x0065883E File Offset: 0x00656C3E
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521888;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06015107 RID: 86279 RVA: 0x00658876 File Offset: 0x00656C76
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9F8 RID: 59896
		private BE_Target method_p0;

		// Token: 0x0400E9F9 RID: 59897
		private int method_p1;

		// Token: 0x0400E9FA RID: 59898
		private int method_p2;

		// Token: 0x0400E9FB RID: 59899
		private int method_p3;

		// Token: 0x0400E9FC RID: 59900
		private int method_p4;
	}
}
