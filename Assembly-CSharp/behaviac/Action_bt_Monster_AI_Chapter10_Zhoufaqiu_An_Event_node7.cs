using System;

namespace behaviac
{
	// Token: 0x02003162 RID: 12642
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node7 : Action
	{
		// Token: 0x06014B5F RID: 84831 RVA: 0x0063CC9E File Offset: 0x0063B09E
		public Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node7()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 0;
		}

		// Token: 0x06014B60 RID: 84832 RVA: 0x0063CCC0 File Offset: 0x0063B0C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E4D4 RID: 58580
		private int method_p0;

		// Token: 0x0400E4D5 RID: 58581
		private int method_p1;
	}
}
