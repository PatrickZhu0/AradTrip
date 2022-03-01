using System;

namespace behaviac
{
	// Token: 0x02003E01 RID: 15873
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node10 : Action
	{
		// Token: 0x0601638C RID: 91020 RVA: 0x006B7C23 File Offset: 0x006B6023
		public Action_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x0601638D RID: 91021 RVA: 0x006B7C44 File Offset: 0x006B6044
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBF4 RID: 64500
		private BE_Target method_p0;

		// Token: 0x0400FBF5 RID: 64501
		private int method_p1;
	}
}
