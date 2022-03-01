using System;

namespace behaviac
{
	// Token: 0x02002DC8 RID: 11720
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node13 : Action
	{
		// Token: 0x0601446F RID: 83055 RVA: 0x00617A1B File Offset: 0x00615E1B
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "所有冒险家跟随护盾躲避伤害！";
			this.method_p1 = 7f;
			this.method_p2 = 2;
		}

		// Token: 0x06014470 RID: 83056 RVA: 0x00617A47 File Offset: 0x00615E47
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE31 RID: 56881
		private string method_p0;

		// Token: 0x0400DE32 RID: 56882
		private float method_p1;

		// Token: 0x0400DE33 RID: 56883
		private int method_p2;
	}
}
