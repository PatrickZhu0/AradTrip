using System;

namespace behaviac
{
	// Token: 0x02003CCE RID: 15566
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node44 : Action
	{
		// Token: 0x0601613E RID: 90430 RVA: 0x006AC77B File Offset: 0x006AAB7B
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570212;
		}

		// Token: 0x0601613F RID: 90431 RVA: 0x006AC79C File Offset: 0x006AAB9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9EF RID: 63983
		private BE_Target method_p0;

		// Token: 0x0400F9F0 RID: 63984
		private int method_p1;
	}
}
