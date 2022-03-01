using System;

namespace behaviac
{
	// Token: 0x02002D9F RID: 11679
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node48 : Action
	{
		// Token: 0x0601441F RID: 82975 RVA: 0x00615DD2 File Offset: 0x006141D2
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 3;
		}

		// Token: 0x06014420 RID: 82976 RVA: 0x00615DEF File Offset: 0x006141EF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDE6 RID: 56806
		private int method_p0;

		// Token: 0x0400DDE7 RID: 56807
		private int method_p1;
	}
}
