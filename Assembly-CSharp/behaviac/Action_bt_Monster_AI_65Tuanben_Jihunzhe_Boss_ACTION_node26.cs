using System;

namespace behaviac
{
	// Token: 0x02002F08 RID: 12040
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node26 : Action
	{
		// Token: 0x060146E7 RID: 83687 RVA: 0x0062569E File Offset: 0x00623A9E
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x060146E8 RID: 83688 RVA: 0x006256BB File Offset: 0x00623ABB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E060 RID: 57440
		private int method_p0;

		// Token: 0x0400E061 RID: 57441
		private int method_p1;
	}
}
