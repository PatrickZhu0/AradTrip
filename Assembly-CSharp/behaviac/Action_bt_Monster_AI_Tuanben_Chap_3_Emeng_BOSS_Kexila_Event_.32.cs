using System;

namespace behaviac
{
	// Token: 0x020038CD RID: 14541
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node20 : Action
	{
		// Token: 0x06015979 RID: 88441 RVA: 0x00684476 File Offset: 0x00682876
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521641;
			this.method_p2 = 1000;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x0601597A RID: 88442 RVA: 0x006844B1 File Offset: 0x006828B1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F330 RID: 62256
		private BE_Target method_p0;

		// Token: 0x0400F331 RID: 62257
		private int method_p1;

		// Token: 0x0400F332 RID: 62258
		private int method_p2;

		// Token: 0x0400F333 RID: 62259
		private int method_p3;

		// Token: 0x0400F334 RID: 62260
		private int method_p4;
	}
}
