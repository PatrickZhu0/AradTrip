using System;

namespace behaviac
{
	// Token: 0x02003806 RID: 14342
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node8 : Action
	{
		// Token: 0x060157FD RID: 88061 RVA: 0x0067D0E2 File Offset: 0x0067B4E2
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521623;
		}

		// Token: 0x060157FE RID: 88062 RVA: 0x0067D103 File Offset: 0x0067B503
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1C5 RID: 61893
		private BE_Target method_p0;

		// Token: 0x0400F1C6 RID: 61894
		private int method_p1;
	}
}
