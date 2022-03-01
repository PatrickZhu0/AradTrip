using System;

namespace behaviac
{
	// Token: 0x02003818 RID: 14360
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node16 : Action
	{
		// Token: 0x0601581F RID: 88095 RVA: 0x0067D946 File Offset: 0x0067BD46
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521657;
		}

		// Token: 0x06015820 RID: 88096 RVA: 0x0067D967 File Offset: 0x0067BD67
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1E2 RID: 61922
		private BE_Target method_p0;

		// Token: 0x0400F1E3 RID: 61923
		private int method_p1;
	}
}
