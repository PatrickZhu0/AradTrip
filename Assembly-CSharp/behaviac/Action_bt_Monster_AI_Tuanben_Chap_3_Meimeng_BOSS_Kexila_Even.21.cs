using System;

namespace behaviac
{
	// Token: 0x0200396C RID: 14700
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node44 : Action
	{
		// Token: 0x06015AAF RID: 88751 RVA: 0x0068B45F File Offset: 0x0068985F
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570212;
		}

		// Token: 0x06015AB0 RID: 88752 RVA: 0x0068B480 File Offset: 0x00689880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F454 RID: 62548
		private BE_Target method_p0;

		// Token: 0x0400F455 RID: 62549
		private int method_p1;
	}
}
