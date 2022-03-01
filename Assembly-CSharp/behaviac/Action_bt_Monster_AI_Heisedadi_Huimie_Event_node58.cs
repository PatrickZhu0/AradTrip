using System;

namespace behaviac
{
	// Token: 0x02003430 RID: 13360
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node58 : Action
	{
		// Token: 0x060150AE RID: 86190 RVA: 0x00656D91 File Offset: 0x00655191
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node58()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521754;
			this.method_p2 = 200;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060150AF RID: 86191 RVA: 0x00656DCC File Offset: 0x006551CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E981 RID: 59777
		private BE_Target method_p0;

		// Token: 0x0400E982 RID: 59778
		private int method_p1;

		// Token: 0x0400E983 RID: 59779
		private int method_p2;

		// Token: 0x0400E984 RID: 59780
		private int method_p3;

		// Token: 0x0400E985 RID: 59781
		private int method_p4;
	}
}
