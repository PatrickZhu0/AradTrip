using System;

namespace behaviac
{
	// Token: 0x020035A9 RID: 13737
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node12 : Action
	{
		// Token: 0x06015381 RID: 86913 RVA: 0x006652D3 File Offset: 0x006636D3
		public Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06015382 RID: 86914 RVA: 0x006652F4 File Offset: 0x006636F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED4C RID: 60748
		private BE_Target method_p0;

		// Token: 0x0400ED4D RID: 60749
		private int method_p1;
	}
}
