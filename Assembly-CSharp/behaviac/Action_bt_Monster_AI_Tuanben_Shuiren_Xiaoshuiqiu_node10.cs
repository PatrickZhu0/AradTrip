using System;

namespace behaviac
{
	// Token: 0x02003B76 RID: 15222
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node10 : Action
	{
		// Token: 0x06015EA0 RID: 89760 RVA: 0x0069F519 File Offset: 0x0069D919
		public Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 87060031;
			this.method_p1 = false;
		}

		// Token: 0x06015EA1 RID: 89761 RVA: 0x0069F53A File Offset: 0x0069D93A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F766 RID: 63334
		private int method_p0;

		// Token: 0x0400F767 RID: 63335
		private bool method_p1;
	}
}
