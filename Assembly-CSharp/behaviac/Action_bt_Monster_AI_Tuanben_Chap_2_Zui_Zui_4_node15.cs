using System;

namespace behaviac
{
	// Token: 0x02003817 RID: 14359
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node15 : Action
	{
		// Token: 0x0601581D RID: 88093 RVA: 0x0067D90B File Offset: 0x0067BD0B
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521623;
		}

		// Token: 0x0601581E RID: 88094 RVA: 0x0067D92C File Offset: 0x0067BD2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1E0 RID: 61920
		private BE_Target method_p0;

		// Token: 0x0400F1E1 RID: 61921
		private int method_p1;
	}
}
