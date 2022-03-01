using System;

namespace behaviac
{
	// Token: 0x020030DB RID: 12507
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Heianquyu_Event_node4 : Action
	{
		// Token: 0x06014A6C RID: 84588 RVA: 0x0063807B File Offset: 0x0063647B
		public Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Heianquyu_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 200;
			this.method_p1 = 0;
		}

		// Token: 0x06014A6D RID: 84589 RVA: 0x0063809C File Offset: 0x0063649C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E3D5 RID: 58325
		private int method_p0;

		// Token: 0x0400E3D6 RID: 58326
		private int method_p1;
	}
}
