using System;

namespace behaviac
{
	// Token: 0x0200389C RID: 14492
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node15 : Action
	{
		// Token: 0x0601591A RID: 88346 RVA: 0x0068303B File Offset: 0x0068143B
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521641;
			this.method_p2 = 1000;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x0601591B RID: 88347 RVA: 0x00683076 File Offset: 0x00681476
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2AA RID: 62122
		private BE_Target method_p0;

		// Token: 0x0400F2AB RID: 62123
		private int method_p1;

		// Token: 0x0400F2AC RID: 62124
		private int method_p2;

		// Token: 0x0400F2AD RID: 62125
		private int method_p3;

		// Token: 0x0400F2AE RID: 62126
		private int method_p4;
	}
}
