using System;

namespace behaviac
{
	// Token: 0x02003C07 RID: 15367
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node41 : Action
	{
		// Token: 0x06015FB9 RID: 90041 RVA: 0x006A49BE File Offset: 0x006A2DBE
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 1;
		}

		// Token: 0x06015FBA RID: 90042 RVA: 0x006A49DB File Offset: 0x006A2DDB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F83C RID: 63548
		private int method_p0;

		// Token: 0x0400F83D RID: 63549
		private int method_p1;
	}
}
