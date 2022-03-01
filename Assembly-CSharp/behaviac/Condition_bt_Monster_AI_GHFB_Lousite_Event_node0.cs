using System;

namespace behaviac
{
	// Token: 0x020032CE RID: 13006
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_Lousite_Event_node0 : Condition
	{
		// Token: 0x06014E0D RID: 85517 RVA: 0x0064A27E File Offset: 0x0064867E
		public Condition_bt_Monster_AI_GHFB_Lousite_Event_node0()
		{
			this.opl_params = new object[2];
			this.opl_params[0] = 120000;
			this.opl_params[1] = 1;
		}

		// Token: 0x06014E0E RID: 85518 RVA: 0x0064A2B4 File Offset: 0x006486B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = (bool)AgentMetaVisitor.ExecuteMethod(pAgent, "Condition_IsTimeUp", this.opl_params);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6F1 RID: 59121
		private object[] opl_params;
	}
}
