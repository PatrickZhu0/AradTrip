using System;

namespace behaviac
{
	// Token: 0x0200379C RID: 14236
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node30 : Action
	{
		// Token: 0x0601573D RID: 87869 RVA: 0x006794D4 File Offset: 0x006778D4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521666;
		}

		// Token: 0x0601573E RID: 87870 RVA: 0x006794F5 File Offset: 0x006778F5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0ED RID: 61677
		private BE_Target method_p0;

		// Token: 0x0400F0EE RID: 61678
		private int method_p1;
	}
}
