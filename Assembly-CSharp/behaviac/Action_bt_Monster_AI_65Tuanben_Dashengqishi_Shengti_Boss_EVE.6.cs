using System;

namespace behaviac
{
	// Token: 0x02002E90 RID: 11920
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node13 : Action
	{
		// Token: 0x060145FB RID: 83451 RVA: 0x00620ABF File Offset: 0x0061EEBF
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "进入剑影躲避伤害！进入同一个剑影，剑影将爆炸！";
			this.method_p1 = 9f;
			this.method_p2 = 2;
		}

		// Token: 0x060145FC RID: 83452 RVA: 0x00620AEB File Offset: 0x0061EEEB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF7F RID: 57215
		private string method_p0;

		// Token: 0x0400DF80 RID: 57216
		private float method_p1;

		// Token: 0x0400DF81 RID: 57217
		private int method_p2;
	}
}
