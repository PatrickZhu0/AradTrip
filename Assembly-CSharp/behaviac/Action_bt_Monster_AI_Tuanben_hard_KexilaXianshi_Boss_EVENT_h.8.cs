using System;

namespace behaviac
{
	// Token: 0x02003CC5 RID: 15557
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node56 : Action
	{
		// Token: 0x0601612C RID: 90412 RVA: 0x006AC4D8 File Offset: 0x006AA8D8
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node56()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x0601612D RID: 90413 RVA: 0x006AC4F9 File Offset: 0x006AA8F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9DB RID: 63963
		private BE_Target method_p0;

		// Token: 0x0400F9DC RID: 63964
		private int method_p1;
	}
}
