using System;

namespace behaviac
{
	// Token: 0x0200342F RID: 13359
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node57 : Action
	{
		// Token: 0x060150AC RID: 86188 RVA: 0x00656D2A File Offset: 0x0065512A
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node57()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521750;
			this.method_p2 = 20000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060150AD RID: 86189 RVA: 0x00656D65 File Offset: 0x00655165
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E97C RID: 59772
		private BE_Target method_p0;

		// Token: 0x0400E97D RID: 59773
		private int method_p1;

		// Token: 0x0400E97E RID: 59774
		private int method_p2;

		// Token: 0x0400E97F RID: 59775
		private int method_p3;

		// Token: 0x0400E980 RID: 59776
		private int method_p4;
	}
}
