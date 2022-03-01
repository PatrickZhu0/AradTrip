using System;

namespace behaviac
{
	// Token: 0x02003DD1 RID: 15825
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node6 : Action
	{
		// Token: 0x06016330 RID: 90928 RVA: 0x006B6261 File Offset: 0x006B4661
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2402;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016331 RID: 90929 RVA: 0x006B629B File Offset: 0x006B469B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB93 RID: 64403
		private BE_Target method_p0;

		// Token: 0x0400FB94 RID: 64404
		private int method_p1;

		// Token: 0x0400FB95 RID: 64405
		private int method_p2;

		// Token: 0x0400FB96 RID: 64406
		private int method_p3;

		// Token: 0x0400FB97 RID: 64407
		private int method_p4;
	}
}
