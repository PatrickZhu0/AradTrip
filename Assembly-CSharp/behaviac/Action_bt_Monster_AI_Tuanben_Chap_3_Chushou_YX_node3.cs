using System;

namespace behaviac
{
	// Token: 0x02003829 RID: 14377
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_node3 : Action
	{
		// Token: 0x0601583D RID: 88125 RVA: 0x0067E598 File Offset: 0x0067C998
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 0;
		}

		// Token: 0x0601583E RID: 88126 RVA: 0x0067E5BC File Offset: 0x0067C9BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F1FC RID: 61948
		private int method_p0;

		// Token: 0x0400F1FD RID: 61949
		private int method_p1;
	}
}
