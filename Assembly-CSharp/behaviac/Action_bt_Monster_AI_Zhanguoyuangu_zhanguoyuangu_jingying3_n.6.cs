using System;

namespace behaviac
{
	// Token: 0x02003F67 RID: 16231
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node15 : Action
	{
		// Token: 0x0601663C RID: 91708 RVA: 0x006C5C61 File Offset: 0x006C4061
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "BOSS进入魔化状态，吸收一切伤害";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x0601663D RID: 91709 RVA: 0x006C5C8D File Offset: 0x006C408D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE88 RID: 65160
		private string method_p0;

		// Token: 0x0400FE89 RID: 65161
		private float method_p1;

		// Token: 0x0400FE8A RID: 65162
		private int method_p2;
	}
}
