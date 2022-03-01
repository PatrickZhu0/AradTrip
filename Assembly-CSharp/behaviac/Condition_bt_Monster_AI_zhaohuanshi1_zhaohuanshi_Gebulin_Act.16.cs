using System;

namespace behaviac
{
	// Token: 0x0200404A RID: 16458
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node30 : Condition
	{
		// Token: 0x060167F3 RID: 92147 RVA: 0x006CF0F6 File Offset: 0x006CD4F6
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node30()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060167F4 RID: 92148 RVA: 0x006CF10C File Offset: 0x006CD50C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401003E RID: 65598
		private float opl_p0;
	}
}
