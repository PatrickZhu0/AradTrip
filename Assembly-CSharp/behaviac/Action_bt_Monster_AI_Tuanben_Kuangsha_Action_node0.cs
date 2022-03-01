using System;

namespace behaviac
{
	// Token: 0x02003ACB RID: 15051
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node0 : Action
	{
		// Token: 0x06015D55 RID: 89429 RVA: 0x00698949 File Offset: 0x00696D49
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015D56 RID: 89430 RVA: 0x0069895F File Offset: 0x00696D5F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F664 RID: 63076
		private int method_p0;
	}
}
