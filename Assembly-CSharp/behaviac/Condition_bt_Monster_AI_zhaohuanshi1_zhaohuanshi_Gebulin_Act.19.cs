using System;

namespace behaviac
{
	// Token: 0x0200404E RID: 16462
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node35 : Condition
	{
		// Token: 0x060167FB RID: 92155 RVA: 0x006CF2AA File Offset: 0x006CD6AA
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node35()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060167FC RID: 92156 RVA: 0x006CF2C0 File Offset: 0x006CD6C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010046 RID: 65606
		private float opl_p0;
	}
}
