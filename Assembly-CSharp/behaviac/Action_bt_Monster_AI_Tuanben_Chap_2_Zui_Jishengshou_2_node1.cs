using System;

namespace behaviac
{
	// Token: 0x020037C6 RID: 14278
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node1 : Action
	{
		// Token: 0x0601578C RID: 87948 RVA: 0x0067B0CB File Offset: 0x006794CB
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521619;
		}

		// Token: 0x0601578D RID: 87949 RVA: 0x0067B0EC File Offset: 0x006794EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F148 RID: 61768
		private BE_Target method_p0;

		// Token: 0x0400F149 RID: 61769
		private int method_p1;
	}
}
