using System;

namespace behaviac
{
	// Token: 0x02003265 RID: 12901
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Tanzhaodeng_Event_node3 : Action
	{
		// Token: 0x06014D48 RID: 85320 RVA: 0x006468F5 File Offset: 0x00644CF5
		public Action_bt_Monster_AI_Digongfuben_Digong_Tanzhaodeng_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "此处有幽魂潜伏，赶快躲进探照灯中，坚持15秒！";
			this.method_p1 = 15f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D49 RID: 85321 RVA: 0x00646921 File Offset: 0x00644D21
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E684 RID: 59012
		private string method_p0;

		// Token: 0x0400E685 RID: 59013
		private float method_p1;

		// Token: 0x0400E686 RID: 59014
		private int method_p2;
	}
}
