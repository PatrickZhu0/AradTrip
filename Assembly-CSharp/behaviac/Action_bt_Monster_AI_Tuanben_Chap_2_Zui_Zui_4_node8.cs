using System;

namespace behaviac
{
	// Token: 0x02003811 RID: 14353
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8 : Action
	{
		// Token: 0x06015811 RID: 88081 RVA: 0x0067D716 File Offset: 0x0067BB16
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521623;
		}

		// Token: 0x06015812 RID: 88082 RVA: 0x0067D737 File Offset: 0x0067BB37
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1D7 RID: 61911
		private BE_Target method_p0;

		// Token: 0x0400F1D8 RID: 61912
		private int method_p1;
	}
}
