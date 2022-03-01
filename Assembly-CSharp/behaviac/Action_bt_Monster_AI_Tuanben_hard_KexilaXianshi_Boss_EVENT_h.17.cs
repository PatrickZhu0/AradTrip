using System;

namespace behaviac
{
	// Token: 0x02003CD4 RID: 15572
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node113 : Action
	{
		// Token: 0x0601614A RID: 90442 RVA: 0x006AC909 File Offset: 0x006AAD09
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node113()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570106;
		}

		// Token: 0x0601614B RID: 90443 RVA: 0x006AC92A File Offset: 0x006AAD2A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9FB RID: 63995
		private BE_Target method_p0;

		// Token: 0x0400F9FC RID: 63996
		private int method_p1;
	}
}
