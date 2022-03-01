using System;

namespace behaviac
{
	// Token: 0x02003824 RID: 14372
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node3 : Action
	{
		// Token: 0x06015835 RID: 88117 RVA: 0x0067E200 File Offset: 0x0067C600
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 16;
			this.method_p2 = 3600000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015836 RID: 88118 RVA: 0x0067E238 File Offset: 0x0067C638
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1EF RID: 61935
		private BE_Target method_p0;

		// Token: 0x0400F1F0 RID: 61936
		private int method_p1;

		// Token: 0x0400F1F1 RID: 61937
		private int method_p2;

		// Token: 0x0400F1F2 RID: 61938
		private int method_p3;

		// Token: 0x0400F1F3 RID: 61939
		private int method_p4;
	}
}
