using System;

namespace behaviac
{
	// Token: 0x02003DF2 RID: 15858
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node6 : Action
	{
		// Token: 0x0601636F RID: 90991 RVA: 0x006B7479 File Offset: 0x006B5879
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2403;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016370 RID: 90992 RVA: 0x006B74B3 File Offset: 0x006B58B3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBD5 RID: 64469
		private BE_Target method_p0;

		// Token: 0x0400FBD6 RID: 64470
		private int method_p1;

		// Token: 0x0400FBD7 RID: 64471
		private int method_p2;

		// Token: 0x0400FBD8 RID: 64472
		private int method_p3;

		// Token: 0x0400FBD9 RID: 64473
		private int method_p4;
	}
}
