using System;

namespace behaviac
{
	// Token: 0x02003CC4 RID: 15556
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node53 : Action
	{
		// Token: 0x0601612A RID: 90410 RVA: 0x006AC49D File Offset: 0x006AA89D
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
		}

		// Token: 0x0601612B RID: 90411 RVA: 0x006AC4BE File Offset: 0x006AA8BE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9D9 RID: 63961
		private BE_Target method_p0;

		// Token: 0x0400F9DA RID: 63962
		private int method_p1;
	}
}
