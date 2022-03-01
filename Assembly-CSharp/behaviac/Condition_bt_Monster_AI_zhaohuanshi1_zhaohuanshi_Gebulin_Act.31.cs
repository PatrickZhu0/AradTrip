using System;

namespace behaviac
{
	// Token: 0x0200405E RID: 16478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node55 : Condition
	{
		// Token: 0x0601681B RID: 92187 RVA: 0x006CF97A File Offset: 0x006CDD7A
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node55()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601681C RID: 92188 RVA: 0x006CF990 File Offset: 0x006CDD90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010066 RID: 65638
		private float opl_p0;
	}
}
