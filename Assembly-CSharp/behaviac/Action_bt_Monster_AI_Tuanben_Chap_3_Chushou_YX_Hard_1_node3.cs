using System;

namespace behaviac
{
	// Token: 0x02003835 RID: 14389
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_1_node3 : Action
	{
		// Token: 0x06015852 RID: 88146 RVA: 0x0067EB6A File Offset: 0x0067CF6A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_1_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 180000;
			this.method_p1 = 0;
		}

		// Token: 0x06015853 RID: 88147 RVA: 0x0067EB8C File Offset: 0x0067CF8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F217 RID: 61975
		private int method_p0;

		// Token: 0x0400F218 RID: 61976
		private int method_p1;
	}
}
