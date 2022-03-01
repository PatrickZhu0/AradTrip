using System;

namespace behaviac
{
	// Token: 0x02003819 RID: 14361
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node14 : Action
	{
		// Token: 0x06015821 RID: 88097 RVA: 0x0067D981 File Offset: 0x0067BD81
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521660;
		}

		// Token: 0x06015822 RID: 88098 RVA: 0x0067D9A2 File Offset: 0x0067BDA2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1E4 RID: 61924
		private BE_Target method_p0;

		// Token: 0x0400F1E5 RID: 61925
		private int method_p1;
	}
}
