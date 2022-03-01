using System;

namespace behaviac
{
	// Token: 0x020037B2 RID: 14258
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node30 : Action
	{
		// Token: 0x06015767 RID: 87911 RVA: 0x0067A1BC File Offset: 0x006785BC
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521666;
		}

		// Token: 0x06015768 RID: 87912 RVA: 0x0067A1DD File Offset: 0x006785DD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F112 RID: 61714
		private BE_Target method_p0;

		// Token: 0x0400F113 RID: 61715
		private int method_p1;
	}
}
