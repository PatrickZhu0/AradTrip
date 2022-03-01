using System;

namespace behaviac
{
	// Token: 0x02004052 RID: 16466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node40 : Condition
	{
		// Token: 0x06016803 RID: 92163 RVA: 0x006CF45E File Offset: 0x006CD85E
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node40()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06016804 RID: 92164 RVA: 0x006CF474 File Offset: 0x006CD874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401004E RID: 65614
		private float opl_p0;
	}
}
