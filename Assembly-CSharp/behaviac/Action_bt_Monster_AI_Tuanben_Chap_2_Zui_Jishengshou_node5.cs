using System;

namespace behaviac
{
	// Token: 0x020037B8 RID: 14264
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node5 : Action
	{
		// Token: 0x06015772 RID: 87922 RVA: 0x0067A97B File Offset: 0x00678D7B
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 30000;
			this.method_p1 = 0;
		}

		// Token: 0x06015773 RID: 87923 RVA: 0x0067A99C File Offset: 0x00678D9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F11F RID: 61727
		private int method_p0;

		// Token: 0x0400F120 RID: 61728
		private int method_p1;
	}
}
