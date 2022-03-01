using System;

namespace behaviac
{
	// Token: 0x020038AF RID: 14511
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node47 : Action
	{
		// Token: 0x0601593D RID: 88381 RVA: 0x00683A86 File Offset: 0x00681E86
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601593E RID: 88382 RVA: 0x00683ABD File Offset: 0x00681EBD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2DA RID: 62170
		private BE_Target method_p0;

		// Token: 0x0400F2DB RID: 62171
		private int method_p1;

		// Token: 0x0400F2DC RID: 62172
		private int method_p2;

		// Token: 0x0400F2DD RID: 62173
		private int method_p3;

		// Token: 0x0400F2DE RID: 62174
		private int method_p4;
	}
}
