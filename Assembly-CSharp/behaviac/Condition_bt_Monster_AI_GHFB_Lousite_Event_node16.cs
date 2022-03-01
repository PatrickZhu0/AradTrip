using System;

namespace behaviac
{
	// Token: 0x020032CB RID: 13003
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_Lousite_Event_node16 : Condition
	{
		// Token: 0x06014E07 RID: 85511 RVA: 0x0064A11D File Offset: 0x0064851D
		public Condition_bt_Monster_AI_GHFB_Lousite_Event_node16()
		{
			this.opl_params = new object[2];
			this.opl_params[0] = 180000;
			this.opl_params[1] = 0;
		}

		// Token: 0x06014E08 RID: 85512 RVA: 0x0064A154 File Offset: 0x00648554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = (bool)AgentMetaVisitor.ExecuteMethod(pAgent, "Condition_IsTimeUp", this.opl_params);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6ED RID: 59117
		private object[] opl_params;
	}
}
