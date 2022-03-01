using System;

namespace behaviac
{
	// Token: 0x02003DBA RID: 15802
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node20 : Action
	{
		// Token: 0x06016304 RID: 90884 RVA: 0x006B50FD File Offset: 0x006B34FD
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523803;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016305 RID: 90885 RVA: 0x006B5137 File Offset: 0x006B3537
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB56 RID: 64342
		private BE_Target method_p0;

		// Token: 0x0400FB57 RID: 64343
		private int method_p1;

		// Token: 0x0400FB58 RID: 64344
		private int method_p2;

		// Token: 0x0400FB59 RID: 64345
		private int method_p3;

		// Token: 0x0400FB5A RID: 64346
		private int method_p4;
	}
}
