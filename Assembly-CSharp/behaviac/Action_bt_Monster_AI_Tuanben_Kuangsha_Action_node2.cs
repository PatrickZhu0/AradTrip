using System;

namespace behaviac
{
	// Token: 0x02003ABD RID: 15037
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node2 : Action
	{
		// Token: 0x06015D39 RID: 89401 RVA: 0x0069851A File Offset: 0x0069691A
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015D3A RID: 89402 RVA: 0x00698530 File Offset: 0x00696930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F652 RID: 63058
		private int method_p0;
	}
}
