using System;

namespace behaviac
{
	// Token: 0x0200349B RID: 13467
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node45 : Action
	{
		// Token: 0x0601517F RID: 86399 RVA: 0x0065AA03 File Offset: 0x00658E03
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node45()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 69;
		}

		// Token: 0x06015180 RID: 86400 RVA: 0x0065AA21 File Offset: 0x00658E21
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA80 RID: 60032
		private BE_Target method_p0;

		// Token: 0x0400EA81 RID: 60033
		private int method_p1;
	}
}
