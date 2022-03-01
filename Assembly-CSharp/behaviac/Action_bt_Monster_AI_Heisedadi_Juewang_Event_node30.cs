using System;

namespace behaviac
{
	// Token: 0x02003493 RID: 13459
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node30 : Action
	{
		// Token: 0x0601516F RID: 86383 RVA: 0x0065A74E File Offset: 0x00658B4E
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node30()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1500;
			this.method_p1 = 4;
		}

		// Token: 0x06015170 RID: 86384 RVA: 0x0065A770 File Offset: 0x00658B70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EA6A RID: 60010
		private int method_p0;

		// Token: 0x0400EA6B RID: 60011
		private int method_p1;
	}
}
