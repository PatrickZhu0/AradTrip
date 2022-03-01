using System;

namespace behaviac
{
	// Token: 0x02003DCC RID: 15820
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node24 : Action
	{
		// Token: 0x06016327 RID: 90919 RVA: 0x006B5B3D File Offset: 0x006B3F3D
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52173;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016328 RID: 90920 RVA: 0x006B5B77 File Offset: 0x006B3F77
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB88 RID: 64392
		private BE_Target method_p0;

		// Token: 0x0400FB89 RID: 64393
		private int method_p1;

		// Token: 0x0400FB8A RID: 64394
		private int method_p2;

		// Token: 0x0400FB8B RID: 64395
		private int method_p3;

		// Token: 0x0400FB8C RID: 64396
		private int method_p4;
	}
}
