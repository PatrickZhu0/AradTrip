using System;

namespace behaviac
{
	// Token: 0x02003AAA RID: 15018
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node40 : Action
	{
		// Token: 0x06015D16 RID: 89366 RVA: 0x00697A6A File Offset: 0x00695E6A
		public Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06015D17 RID: 89367 RVA: 0x00697A87 File Offset: 0x00695E87
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F638 RID: 63032
		private int method_p0;

		// Token: 0x0400F639 RID: 63033
		private int method_p1;
	}
}
