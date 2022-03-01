using System;

namespace behaviac
{
	// Token: 0x02003F49 RID: 16201
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node15 : Action
	{
		// Token: 0x06016602 RID: 91650 RVA: 0x006C4B79 File Offset: 0x006C2F79
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔化状态，吸收一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016603 RID: 91651 RVA: 0x006C4BA5 File Offset: 0x006C2FA5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE38 RID: 65080
		private string method_p0;

		// Token: 0x0400FE39 RID: 65081
		private float method_p1;

		// Token: 0x0400FE3A RID: 65082
		private int method_p2;
	}
}
