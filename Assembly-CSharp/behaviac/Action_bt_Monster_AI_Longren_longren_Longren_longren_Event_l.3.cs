using System;

namespace behaviac
{
	// Token: 0x020035A6 RID: 13734
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node10 : Action
	{
		// Token: 0x0601537B RID: 86907 RVA: 0x006651F3 File Offset: 0x006635F3
		public Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x0601537C RID: 86908 RVA: 0x00665214 File Offset: 0x00663614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED46 RID: 60742
		private BE_Target method_p0;

		// Token: 0x0400ED47 RID: 60743
		private int method_p1;
	}
}
