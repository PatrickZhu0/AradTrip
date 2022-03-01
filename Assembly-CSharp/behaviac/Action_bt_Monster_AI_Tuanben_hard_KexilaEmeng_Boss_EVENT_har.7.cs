using System;

namespace behaviac
{
	// Token: 0x02003BD0 RID: 15312
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node56 : Action
	{
		// Token: 0x06015F4D RID: 89933 RVA: 0x006A299C File Offset: 0x006A0D9C
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node56()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x06015F4E RID: 89934 RVA: 0x006A29BD File Offset: 0x006A0DBD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7E6 RID: 63462
		private BE_Target method_p0;

		// Token: 0x0400F7E7 RID: 63463
		private int method_p1;
	}
}
