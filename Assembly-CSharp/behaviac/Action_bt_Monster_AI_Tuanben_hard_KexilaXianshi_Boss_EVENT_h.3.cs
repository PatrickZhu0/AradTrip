using System;

namespace behaviac
{
	// Token: 0x02003CBE RID: 15550
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node47 : Action
	{
		// Token: 0x0601611E RID: 90398 RVA: 0x006AC276 File Offset: 0x006AA676
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601611F RID: 90399 RVA: 0x006AC2AD File Offset: 0x006AA6AD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9C3 RID: 63939
		private BE_Target method_p0;

		// Token: 0x0400F9C4 RID: 63940
		private int method_p1;

		// Token: 0x0400F9C5 RID: 63941
		private int method_p2;

		// Token: 0x0400F9C6 RID: 63942
		private int method_p3;

		// Token: 0x0400F9C7 RID: 63943
		private int method_p4;
	}
}
