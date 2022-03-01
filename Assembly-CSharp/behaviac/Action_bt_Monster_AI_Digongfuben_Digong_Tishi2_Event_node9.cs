using System;

namespace behaviac
{
	// Token: 0x0200327D RID: 12925
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node9 : Action
	{
		// Token: 0x06014D76 RID: 85366 RVA: 0x0064728B File Offset: 0x0064568B
		public Action_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "找到了宝藏地图！可以查看完整的地宫地图了！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D77 RID: 85367 RVA: 0x006472B7 File Offset: 0x006456B7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E690 RID: 59024
		private string method_p0;

		// Token: 0x0400E691 RID: 59025
		private float method_p1;

		// Token: 0x0400E692 RID: 59026
		private int method_p2;
	}
}
