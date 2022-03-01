using System;

namespace behaviac
{
	// Token: 0x02003481 RID: 13441
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node1 : Action
	{
		// Token: 0x0601514B RID: 86347 RVA: 0x0065A22F File Offset: 0x0065862F
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 560001;
		}

		// Token: 0x0601514C RID: 86348 RVA: 0x0065A250 File Offset: 0x00658650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA4C RID: 59980
		private BE_Target method_p0;

		// Token: 0x0400EA4D RID: 59981
		private int method_p1;
	}
}
