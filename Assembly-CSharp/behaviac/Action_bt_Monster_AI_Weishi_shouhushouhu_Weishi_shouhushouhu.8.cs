using System;

namespace behaviac
{
	// Token: 0x02003DF7 RID: 15863
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node11 : Action
	{
		// Token: 0x06016379 RID: 91001 RVA: 0x006B75FD File Offset: 0x006B59FD
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2503;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601637A RID: 91002 RVA: 0x006B7637 File Offset: 0x006B5A37
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBE0 RID: 64480
		private BE_Target method_p0;

		// Token: 0x0400FBE1 RID: 64481
		private int method_p1;

		// Token: 0x0400FBE2 RID: 64482
		private int method_p2;

		// Token: 0x0400FBE3 RID: 64483
		private int method_p3;

		// Token: 0x0400FBE4 RID: 64484
		private int method_p4;
	}
}
