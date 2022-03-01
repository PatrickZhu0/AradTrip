using System;

namespace behaviac
{
	// Token: 0x02003DC4 RID: 15812
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node14 : Action
	{
		// Token: 0x06016317 RID: 90903 RVA: 0x006B589B File Offset: 0x006B3C9B
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52171;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016318 RID: 90904 RVA: 0x006B58D5 File Offset: 0x006B3CD5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB6F RID: 64367
		private BE_Target method_p0;

		// Token: 0x0400FB70 RID: 64368
		private int method_p1;

		// Token: 0x0400FB71 RID: 64369
		private int method_p2;

		// Token: 0x0400FB72 RID: 64370
		private int method_p3;

		// Token: 0x0400FB73 RID: 64371
		private int method_p4;
	}
}
