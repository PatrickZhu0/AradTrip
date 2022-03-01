using System;

namespace behaviac
{
	// Token: 0x020038CB RID: 14539
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node4 : Action
	{
		// Token: 0x06015975 RID: 88437 RVA: 0x006843CB File Offset: 0x006827CB
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521673;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015976 RID: 88438 RVA: 0x00684403 File Offset: 0x00682803
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F329 RID: 62249
		private BE_Target method_p0;

		// Token: 0x0400F32A RID: 62250
		private int method_p1;

		// Token: 0x0400F32B RID: 62251
		private int method_p2;

		// Token: 0x0400F32C RID: 62252
		private int method_p3;

		// Token: 0x0400F32D RID: 62253
		private int method_p4;
	}
}
