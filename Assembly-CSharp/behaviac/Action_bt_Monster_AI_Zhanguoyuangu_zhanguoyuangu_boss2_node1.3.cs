using System;

namespace behaviac
{
	// Token: 0x02003F20 RID: 16160
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node15 : Action
	{
		// Token: 0x060165B3 RID: 91571 RVA: 0x006C3526 File Offset: 0x006C1926
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔王的意志状态，免疫一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x060165B4 RID: 91572 RVA: 0x006C3552 File Offset: 0x006C1952
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDD4 RID: 64980
		private string method_p0;

		// Token: 0x0400FDD5 RID: 64981
		private float method_p1;

		// Token: 0x0400FDD6 RID: 64982
		private int method_p2;
	}
}
