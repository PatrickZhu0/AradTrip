using System;

namespace behaviac
{
	// Token: 0x02003AAF RID: 15023
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node14 : Action
	{
		// Token: 0x06015D20 RID: 89376 RVA: 0x00697C1A File Offset: 0x0069601A
		public Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 1;
		}

		// Token: 0x06015D21 RID: 89377 RVA: 0x00697C37 File Offset: 0x00696037
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F63F RID: 63039
		private int method_p0;

		// Token: 0x0400F640 RID: 63040
		private int method_p1;
	}
}
