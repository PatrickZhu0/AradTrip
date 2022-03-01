using System;

namespace behaviac
{
	// Token: 0x02003A1B RID: 14875
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node41 : Action
	{
		// Token: 0x06015C00 RID: 89088 RVA: 0x00691D66 File Offset: 0x00690166
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 1;
		}

		// Token: 0x06015C01 RID: 89089 RVA: 0x00691D83 File Offset: 0x00690183
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F517 RID: 62743
		private int method_p0;

		// Token: 0x0400F518 RID: 62744
		private int method_p1;
	}
}
