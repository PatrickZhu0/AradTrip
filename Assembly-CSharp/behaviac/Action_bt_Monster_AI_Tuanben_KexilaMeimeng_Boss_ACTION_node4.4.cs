using System;

namespace behaviac
{
	// Token: 0x02003A21 RID: 14881
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node40 : Action
	{
		// Token: 0x06015C0C RID: 89100 RVA: 0x00691F79 File Offset: 0x00690379
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06015C0D RID: 89101 RVA: 0x00691F96 File Offset: 0x00690396
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F523 RID: 62755
		private int method_p0;

		// Token: 0x0400F524 RID: 62756
		private int method_p1;
	}
}
