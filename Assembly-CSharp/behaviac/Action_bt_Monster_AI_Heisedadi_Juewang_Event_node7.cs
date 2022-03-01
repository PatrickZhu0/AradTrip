using System;

namespace behaviac
{
	// Token: 0x02003486 RID: 13446
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node7 : Action
	{
		// Token: 0x06015155 RID: 86357 RVA: 0x0065A3E3 File Offset: 0x006587E3
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 560001;
		}

		// Token: 0x06015156 RID: 86358 RVA: 0x0065A404 File Offset: 0x00658804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA55 RID: 59989
		private BE_Target method_p0;

		// Token: 0x0400EA56 RID: 59990
		private int method_p1;
	}
}
