using System;

namespace behaviac
{
	// Token: 0x020031F9 RID: 12793
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node25 : Action
	{
		// Token: 0x06014C7E RID: 85118 RVA: 0x0064268F File Offset: 0x00640A8F
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570275;
		}

		// Token: 0x06014C7F RID: 85119 RVA: 0x006426B0 File Offset: 0x00640AB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5D4 RID: 58836
		private BE_Target method_p0;

		// Token: 0x0400E5D5 RID: 58837
		private int method_p1;
	}
}
