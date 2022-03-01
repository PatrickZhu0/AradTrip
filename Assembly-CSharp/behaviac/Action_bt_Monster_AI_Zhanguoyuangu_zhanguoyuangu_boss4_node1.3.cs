using System;

namespace behaviac
{
	// Token: 0x02003F3A RID: 16186
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node15 : Action
	{
		// Token: 0x060165E5 RID: 91621 RVA: 0x006C437E File Offset: 0x006C277E
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔王的意志状态，免疫一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x060165E6 RID: 91622 RVA: 0x006C43AA File Offset: 0x006C27AA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE10 RID: 65040
		private string method_p0;

		// Token: 0x0400FE11 RID: 65041
		private float method_p1;

		// Token: 0x0400FE12 RID: 65042
		private int method_p2;
	}
}
