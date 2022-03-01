using System;

namespace behaviac
{
	// Token: 0x0200350D RID: 13581
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node67 : Action
	{
		// Token: 0x0601525D RID: 86621 RVA: 0x0065F091 File Offset: 0x0065D491
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node67()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521791;
		}

		// Token: 0x0601525E RID: 86622 RVA: 0x0065F0B2 File Offset: 0x0065D4B2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB9A RID: 60314
		private BE_Target method_p0;

		// Token: 0x0400EB9B RID: 60315
		private int method_p1;
	}
}
