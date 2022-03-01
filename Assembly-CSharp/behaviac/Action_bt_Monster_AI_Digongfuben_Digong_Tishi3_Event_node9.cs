using System;

namespace behaviac
{
	// Token: 0x02003289 RID: 12937
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node9 : Action
	{
		// Token: 0x06014D8D RID: 85389 RVA: 0x006478AF File Offset: 0x00645CAF
		public Action_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "找到了魔王护符！附近的大魔王无法攻击到你了！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D8E RID: 85390 RVA: 0x006478DB File Offset: 0x00645CDB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E696 RID: 59030
		private string method_p0;

		// Token: 0x0400E697 RID: 59031
		private float method_p1;

		// Token: 0x0400E698 RID: 59032
		private int method_p2;
	}
}
