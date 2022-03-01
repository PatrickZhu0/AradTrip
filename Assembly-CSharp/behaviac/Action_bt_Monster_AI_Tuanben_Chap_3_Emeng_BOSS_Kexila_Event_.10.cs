using System;

namespace behaviac
{
	// Token: 0x020038A7 RID: 14503
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node21 : Action
	{
		// Token: 0x06015930 RID: 88368 RVA: 0x006834B6 File Offset: 0x006818B6
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521642;
		}

		// Token: 0x06015931 RID: 88369 RVA: 0x006834D7 File Offset: 0x006818D7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2CE RID: 62158
		private BE_Target method_p0;

		// Token: 0x0400F2CF RID: 62159
		private int method_p1;
	}
}
