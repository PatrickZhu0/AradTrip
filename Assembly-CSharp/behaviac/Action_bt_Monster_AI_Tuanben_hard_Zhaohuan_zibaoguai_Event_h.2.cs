using System;

namespace behaviac
{
	// Token: 0x02003DA0 RID: 15776
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node11 : Action
	{
		// Token: 0x060162D2 RID: 90834 RVA: 0x006B44BE File Offset: 0x006B28BE
		public Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x060162D3 RID: 90835 RVA: 0x006B44DB File Offset: 0x006B28DB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB1F RID: 64287
		private int method_p0;

		// Token: 0x0400FB20 RID: 64288
		private int method_p1;
	}
}
