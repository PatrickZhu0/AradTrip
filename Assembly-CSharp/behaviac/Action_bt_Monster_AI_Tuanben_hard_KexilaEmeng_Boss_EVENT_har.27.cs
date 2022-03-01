using System;

namespace behaviac
{
	// Token: 0x02003BFD RID: 15357
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node29 : Action
	{
		// Token: 0x06015FA6 RID: 90022 RVA: 0x006A3533 File Offset: 0x006A1933
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570151;
		}

		// Token: 0x06015FA7 RID: 90023 RVA: 0x006A3554 File Offset: 0x006A1954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F82F RID: 63535
		private BE_Target method_p0;

		// Token: 0x0400F830 RID: 63536
		private int method_p1;
	}
}
