using System;

namespace behaviac
{
	// Token: 0x020031F2 RID: 12786
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node15 : Action
	{
		// Token: 0x06014C70 RID: 85104 RVA: 0x00642463 File Offset: 0x00640863
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521623;
		}

		// Token: 0x06014C71 RID: 85105 RVA: 0x00642484 File Offset: 0x00640884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5C9 RID: 58825
		private BE_Target method_p0;

		// Token: 0x0400E5CA RID: 58826
		private int method_p1;
	}
}
