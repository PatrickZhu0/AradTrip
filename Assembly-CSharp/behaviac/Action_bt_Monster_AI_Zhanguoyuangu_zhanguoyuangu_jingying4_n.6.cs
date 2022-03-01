using System;

namespace behaviac
{
	// Token: 0x02003F76 RID: 16246
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node15 : Action
	{
		// Token: 0x06016659 RID: 91737 RVA: 0x006C64D5 File Offset: 0x006C48D5
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔化状态，吸收一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x0601665A RID: 91738 RVA: 0x006C6501 File Offset: 0x006C4901
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEB0 RID: 65200
		private string method_p0;

		// Token: 0x0400FEB1 RID: 65201
		private float method_p1;

		// Token: 0x0400FEB2 RID: 65202
		private int method_p2;
	}
}
