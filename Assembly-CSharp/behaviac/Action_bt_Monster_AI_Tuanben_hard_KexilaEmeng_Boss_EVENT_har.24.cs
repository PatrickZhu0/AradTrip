using System;

namespace behaviac
{
	// Token: 0x02003BF4 RID: 15348
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node9 : Action
	{
		// Token: 0x06015F95 RID: 90005 RVA: 0x006A3345 File Offset: 0x006A1745
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 2;
		}

		// Token: 0x06015F96 RID: 90006 RVA: 0x006A3362 File Offset: 0x006A1762
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F826 RID: 63526
		private int method_p0;

		// Token: 0x0400F827 RID: 63527
		private int method_p1;
	}
}
