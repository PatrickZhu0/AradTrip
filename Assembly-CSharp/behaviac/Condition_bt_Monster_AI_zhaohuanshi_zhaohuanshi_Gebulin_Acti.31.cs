using System;

namespace behaviac
{
	// Token: 0x02003FB5 RID: 16309
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node55 : Condition
	{
		// Token: 0x060166D4 RID: 91860 RVA: 0x006C879E File Offset: 0x006C6B9E
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node55()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060166D5 RID: 91861 RVA: 0x006C87B4 File Offset: 0x006C6BB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF27 RID: 65319
		private float opl_p0;
	}
}
