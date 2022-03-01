using System;

namespace behaviac
{
	// Token: 0x02003FAD RID: 16301
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node45 : Condition
	{
		// Token: 0x060166C4 RID: 91844 RVA: 0x006C8436 File Offset: 0x006C6836
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node45()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060166C5 RID: 91845 RVA: 0x006C844C File Offset: 0x006C684C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF17 RID: 65303
		private float opl_p0;
	}
}
