using System;

namespace behaviac
{
	// Token: 0x0200323D RID: 12861
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3 : Action
	{
		// Token: 0x06014CFC RID: 85244 RVA: 0x006452E6 File Offset: 0x006436E6
		public Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "您拥有宝藏钥匙！可以开启大宝箱了！";
			this.method_p1 = 3f;
			this.method_p2 = 2;
		}

		// Token: 0x06014CFD RID: 85245 RVA: 0x00645312 File Offset: 0x00643712
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E655 RID: 58965
		private string method_p0;

		// Token: 0x0400E656 RID: 58966
		private float method_p1;

		// Token: 0x0400E657 RID: 58967
		private int method_p2;
	}
}
