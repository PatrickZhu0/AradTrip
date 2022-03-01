using System;

namespace behaviac
{
	// Token: 0x0200395D RID: 14685
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node52 : Action
	{
		// Token: 0x06015A91 RID: 88721 RVA: 0x0068AFBD File Offset: 0x006893BD
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node52()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "克茜拉获得强化，击破贝希摩斯之心可将强化消除！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015A92 RID: 88722 RVA: 0x0068AFE9 File Offset: 0x006893E9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F42D RID: 62509
		private string method_p0;

		// Token: 0x0400F42E RID: 62510
		private float method_p1;

		// Token: 0x0400F42F RID: 62511
		private int method_p2;
	}
}
