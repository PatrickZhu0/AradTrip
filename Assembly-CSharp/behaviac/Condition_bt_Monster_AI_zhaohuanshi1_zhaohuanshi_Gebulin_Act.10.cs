using System;

namespace behaviac
{
	// Token: 0x02004042 RID: 16450
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node20 : Condition
	{
		// Token: 0x060167E3 RID: 92131 RVA: 0x006CED8E File Offset: 0x006CD18E
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node20()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060167E4 RID: 92132 RVA: 0x006CEDA4 File Offset: 0x006CD1A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401002E RID: 65582
		private float opl_p0;
	}
}
