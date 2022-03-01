using System;

namespace behaviac
{
	// Token: 0x02003295 RID: 12949
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node9 : Action
	{
		// Token: 0x06014DA4 RID: 85412 RVA: 0x00647ED3 File Offset: 0x006462D3
		public Action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "神圣徽章发挥出强大的光芒！大魔王的力量被削弱了！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06014DA5 RID: 85413 RVA: 0x00647EFF File Offset: 0x006462FF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E69C RID: 59036
		private string method_p0;

		// Token: 0x0400E69D RID: 59037
		private float method_p1;

		// Token: 0x0400E69E RID: 59038
		private int method_p2;
	}
}
