using System;

namespace behaviac
{
	// Token: 0x02003159 RID: 12633
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2 : Action
	{
		// Token: 0x06014B50 RID: 84816 RVA: 0x0063C808 File Offset: 0x0063AC08
		public Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 15000;
			this.method_p1 = 0;
		}

		// Token: 0x06014B51 RID: 84817 RVA: 0x0063C82C File Offset: 0x0063AC2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E4CA RID: 58570
		private int method_p0;

		// Token: 0x0400E4CB RID: 58571
		private int method_p1;
	}
}
