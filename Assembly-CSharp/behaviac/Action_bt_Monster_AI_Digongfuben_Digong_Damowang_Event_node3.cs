using System;

namespace behaviac
{
	// Token: 0x02003249 RID: 12873
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3 : Action
	{
		// Token: 0x06014D13 RID: 85267 RVA: 0x006458D5 File Offset: 0x00643CD5
		public Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "神圣徽章发挥出强大的光芒！大魔王变的不堪一击！";
			this.method_p1 = 3f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D14 RID: 85268 RVA: 0x00645901 File Offset: 0x00643D01
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E664 RID: 58980
		private string method_p0;

		// Token: 0x0400E665 RID: 58981
		private float method_p1;

		// Token: 0x0400E666 RID: 58982
		private int method_p2;
	}
}
