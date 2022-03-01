using System;

namespace behaviac
{
	// Token: 0x02003F13 RID: 16147
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node15 : Action
	{
		// Token: 0x0601659A RID: 91546 RVA: 0x006C2DFA File Offset: 0x006C11FA
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔王的意志状态，免疫一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x0601659B RID: 91547 RVA: 0x006C2E26 File Offset: 0x006C1226
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDB6 RID: 64950
		private string method_p0;

		// Token: 0x0400FDB7 RID: 64951
		private float method_p1;

		// Token: 0x0400FDB8 RID: 64952
		private int method_p2;
	}
}
