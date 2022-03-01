using System;

namespace behaviac
{
	// Token: 0x02003807 RID: 14343
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node11 : Action
	{
		// Token: 0x060157FF RID: 88063 RVA: 0x0067D11D File Offset: 0x0067B51D
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521657;
		}

		// Token: 0x06015800 RID: 88064 RVA: 0x0067D13E File Offset: 0x0067B53E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1C7 RID: 61895
		private BE_Target method_p0;

		// Token: 0x0400F1C8 RID: 61896
		private int method_p1;
	}
}
