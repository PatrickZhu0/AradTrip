using System;

namespace behaviac
{
	// Token: 0x02003DB9 RID: 15801
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node18 : Action
	{
		// Token: 0x06016302 RID: 90882 RVA: 0x006B50C2 File Offset: 0x006B34C2
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523802;
		}

		// Token: 0x06016303 RID: 90883 RVA: 0x006B50E3 File Offset: 0x006B34E3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB54 RID: 64340
		private BE_Target method_p0;

		// Token: 0x0400FB55 RID: 64341
		private int method_p1;
	}
}
