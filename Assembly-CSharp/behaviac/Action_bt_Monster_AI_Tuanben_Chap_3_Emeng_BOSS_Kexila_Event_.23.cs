using System;

namespace behaviac
{
	// Token: 0x020038C0 RID: 14528
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node46 : Action
	{
		// Token: 0x0601595F RID: 88415 RVA: 0x00683FC6 File Offset: 0x006823C6
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node46()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
		}

		// Token: 0x06015960 RID: 88416 RVA: 0x00683FE7 File Offset: 0x006823E7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F308 RID: 62216
		private BE_Target method_p0;

		// Token: 0x0400F309 RID: 62217
		private int method_p1;
	}
}
