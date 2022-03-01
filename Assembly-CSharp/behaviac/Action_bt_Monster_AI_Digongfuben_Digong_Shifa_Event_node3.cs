using System;

namespace behaviac
{
	// Token: 0x02003259 RID: 12889
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3 : Action
	{
		// Token: 0x06014D31 RID: 85297 RVA: 0x00646137 File Offset: 0x00644537
		public Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "因携带了魔王护符，附近的大魔王无法攻击到你！";
			this.method_p1 = 3f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D32 RID: 85298 RVA: 0x00646163 File Offset: 0x00644563
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E675 RID: 58997
		private string method_p0;

		// Token: 0x0400E676 RID: 58998
		private float method_p1;

		// Token: 0x0400E677 RID: 58999
		private int method_p2;
	}
}
