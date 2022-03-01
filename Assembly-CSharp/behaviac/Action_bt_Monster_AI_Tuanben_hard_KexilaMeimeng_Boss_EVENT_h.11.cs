using System;

namespace behaviac
{
	// Token: 0x02003C62 RID: 15458
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node66 : Action
	{
		// Token: 0x0601606C RID: 90220 RVA: 0x006A80CD File Offset: 0x006A64CD
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node66()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x0601606D RID: 90221 RVA: 0x006A80F9 File Offset: 0x006A64F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8ED RID: 63725
		private string method_p0;

		// Token: 0x0400F8EE RID: 63726
		private float method_p1;

		// Token: 0x0400F8EF RID: 63727
		private int method_p2;
	}
}
