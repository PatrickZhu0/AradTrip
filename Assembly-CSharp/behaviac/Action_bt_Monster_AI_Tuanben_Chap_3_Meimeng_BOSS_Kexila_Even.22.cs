using System;

namespace behaviac
{
	// Token: 0x0200396D RID: 14701
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node46 : Action
	{
		// Token: 0x06015AB1 RID: 88753 RVA: 0x0068B49A File Offset: 0x0068989A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node46()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
		}

		// Token: 0x06015AB2 RID: 88754 RVA: 0x0068B4BB File Offset: 0x006898BB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F456 RID: 62550
		private BE_Target method_p0;

		// Token: 0x0400F457 RID: 62551
		private int method_p1;
	}
}
