using System;

namespace behaviac
{
	// Token: 0x020031EF RID: 12783
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node8 : Action
	{
		// Token: 0x06014C6A RID: 85098 RVA: 0x0064238D File Offset: 0x0064078D
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570263;
		}

		// Token: 0x06014C6B RID: 85099 RVA: 0x006423AE File Offset: 0x006407AE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5C4 RID: 58820
		private BE_Target method_p0;

		// Token: 0x0400E5C5 RID: 58821
		private int method_p1;
	}
}
