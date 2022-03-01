using System;

namespace behaviac
{
	// Token: 0x02003C67 RID: 15463
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node67 : Action
	{
		// Token: 0x06016076 RID: 90230 RVA: 0x006A823D File Offset: 0x006A663D
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node67()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，超级强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016077 RID: 90231 RVA: 0x006A8269 File Offset: 0x006A6669
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8F8 RID: 63736
		private string method_p0;

		// Token: 0x0400F8F9 RID: 63737
		private float method_p1;

		// Token: 0x0400F8FA RID: 63738
		private int method_p2;
	}
}
