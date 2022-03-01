using System;

namespace behaviac
{
	// Token: 0x02003241 RID: 12865
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node12 : Action
	{
		// Token: 0x06014D04 RID: 85252 RVA: 0x006453DA File Offset: 0x006437DA
		public Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "您没有宝藏钥匙，无法开启宝箱，快去寻找宝藏钥匙吧！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D05 RID: 85253 RVA: 0x00645406 File Offset: 0x00643806
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E659 RID: 58969
		private string method_p0;

		// Token: 0x0400E65A RID: 58970
		private float method_p1;

		// Token: 0x0400E65B RID: 58971
		private int method_p2;
	}
}
