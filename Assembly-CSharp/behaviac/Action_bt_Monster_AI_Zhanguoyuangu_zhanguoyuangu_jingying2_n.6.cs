using System;

namespace behaviac
{
	// Token: 0x02003F58 RID: 16216
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node15 : Action
	{
		// Token: 0x0601661F RID: 91679 RVA: 0x006C53ED File Offset: 0x006C37ED
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔化状态，吸收一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016620 RID: 91680 RVA: 0x006C5419 File Offset: 0x006C3819
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE60 RID: 65120
		private string method_p0;

		// Token: 0x0400FE61 RID: 65121
		private float method_p1;

		// Token: 0x0400FE62 RID: 65122
		private int method_p2;
	}
}
