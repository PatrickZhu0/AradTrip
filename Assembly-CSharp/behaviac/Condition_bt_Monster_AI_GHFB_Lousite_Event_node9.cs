using System;

namespace behaviac
{
	// Token: 0x020032D1 RID: 13009
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_Lousite_Event_node9 : Condition
	{
		// Token: 0x06014E13 RID: 85523 RVA: 0x0064A3DE File Offset: 0x006487DE
		public Condition_bt_Monster_AI_GHFB_Lousite_Event_node9()
		{
			this.opl_params = new object[2];
			this.opl_params[0] = 60000;
			this.opl_params[1] = 2;
		}

		// Token: 0x06014E14 RID: 85524 RVA: 0x0064A414 File Offset: 0x00648814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = (bool)AgentMetaVisitor.ExecuteMethod(pAgent, "Condition_IsTimeUp", this.opl_params);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6F5 RID: 59125
		private object[] opl_params;
	}
}
