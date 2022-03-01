using System;

namespace behaviac
{
	// Token: 0x0200329D RID: 12957
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node2 : Action
	{
		// Token: 0x06014DB2 RID: 85426 RVA: 0x006484FF File Offset: 0x006468FF
		public Action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 30;
			this.method_p2 = 900000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014DB3 RID: 85427 RVA: 0x00648536 File Offset: 0x00646936
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6A5 RID: 59045
		private BE_Target method_p0;

		// Token: 0x0400E6A6 RID: 59046
		private int method_p1;

		// Token: 0x0400E6A7 RID: 59047
		private int method_p2;

		// Token: 0x0400E6A8 RID: 59048
		private int method_p3;

		// Token: 0x0400E6A9 RID: 59049
		private int method_p4;
	}
}
