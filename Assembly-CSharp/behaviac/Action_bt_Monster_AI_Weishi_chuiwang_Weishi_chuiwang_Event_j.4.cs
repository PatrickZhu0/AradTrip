using System;

namespace behaviac
{
	// Token: 0x02003DB2 RID: 15794
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node10 : Action
	{
		// Token: 0x060162F4 RID: 90868 RVA: 0x006B4E5B File Offset: 0x006B325B
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523801;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060162F5 RID: 90869 RVA: 0x006B4E95 File Offset: 0x006B3295
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB3D RID: 64317
		private BE_Target method_p0;

		// Token: 0x0400FB3E RID: 64318
		private int method_p1;

		// Token: 0x0400FB3F RID: 64319
		private int method_p2;

		// Token: 0x0400FB40 RID: 64320
		private int method_p3;

		// Token: 0x0400FB41 RID: 64321
		private int method_p4;
	}
}
