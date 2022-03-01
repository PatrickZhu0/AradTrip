using System;

namespace behaviac
{
	// Token: 0x02004046 RID: 16454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node25 : Condition
	{
		// Token: 0x060167EB RID: 92139 RVA: 0x006CEF42 File Offset: 0x006CD342
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node25()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060167EC RID: 92140 RVA: 0x006CEF58 File Offset: 0x006CD358
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010036 RID: 65590
		private float opl_p0;
	}
}
