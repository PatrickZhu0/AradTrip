using System;

namespace behaviac
{
	// Token: 0x02003F2D RID: 16173
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node15 : Action
	{
		// Token: 0x060165CC RID: 91596 RVA: 0x006C3C52 File Offset: 0x006C2052
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔王的意志状态，免疫一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x060165CD RID: 91597 RVA: 0x006C3C7E File Offset: 0x006C207E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDF2 RID: 65010
		private string method_p0;

		// Token: 0x0400FDF3 RID: 65011
		private float method_p1;

		// Token: 0x0400FDF4 RID: 65012
		private int method_p2;
	}
}
