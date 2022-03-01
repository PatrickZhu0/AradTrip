using System;

namespace behaviac
{
	// Token: 0x02003B97 RID: 15255
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node40 : Action
	{
		// Token: 0x06015EDE RID: 89822 RVA: 0x006A03CA File Offset: 0x0069E7CA
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06015EDF RID: 89823 RVA: 0x006A03E7 File Offset: 0x0069E7E7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F790 RID: 63376
		private int method_p0;

		// Token: 0x0400F791 RID: 63377
		private int method_p1;
	}
}
