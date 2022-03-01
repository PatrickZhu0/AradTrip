using System;

namespace behaviac
{
	// Token: 0x0200396E RID: 14702
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node67 : Action
	{
		// Token: 0x06015AB3 RID: 88755 RVA: 0x0068B4D5 File Offset: 0x006898D5
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node67()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，超级强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015AB4 RID: 88756 RVA: 0x0068B501 File Offset: 0x00689901
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F458 RID: 62552
		private string method_p0;

		// Token: 0x0400F459 RID: 62553
		private float method_p1;

		// Token: 0x0400F45A RID: 62554
		private int method_p2;
	}
}
