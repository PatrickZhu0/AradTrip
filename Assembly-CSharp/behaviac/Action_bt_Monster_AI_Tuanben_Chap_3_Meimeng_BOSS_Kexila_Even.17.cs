using System;

namespace behaviac
{
	// Token: 0x02003964 RID: 14692
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node54 : Action
	{
		// Token: 0x06015A9F RID: 88735 RVA: 0x0068B1F7 File Offset: 0x006895F7
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node54()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得超级强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015AA0 RID: 88736 RVA: 0x0068B223 File Offset: 0x00689623
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F442 RID: 62530
		private string method_p0;

		// Token: 0x0400F443 RID: 62531
		private float method_p1;

		// Token: 0x0400F444 RID: 62532
		private int method_p2;
	}
}
