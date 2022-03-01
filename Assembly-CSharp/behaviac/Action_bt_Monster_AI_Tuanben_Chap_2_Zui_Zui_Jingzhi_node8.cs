using System;

namespace behaviac
{
	// Token: 0x02003822 RID: 14370
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node8 : Action
	{
		// Token: 0x06015831 RID: 88113 RVA: 0x0067E18D File Offset: 0x0067C58D
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 16;
		}

		// Token: 0x06015832 RID: 88114 RVA: 0x0067E1AB File Offset: 0x0067C5AB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1ED RID: 61933
		private BE_Target method_p0;

		// Token: 0x0400F1EE RID: 61934
		private int method_p1;
	}
}
