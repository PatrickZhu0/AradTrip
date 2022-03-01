using System;

namespace behaviac
{
	// Token: 0x0200405A RID: 16474
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node50 : Condition
	{
		// Token: 0x06016813 RID: 92179 RVA: 0x006CF7C6 File Offset: 0x006CDBC6
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node50()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016814 RID: 92180 RVA: 0x006CF7DC File Offset: 0x006CDBDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401005E RID: 65630
		private float opl_p0;
	}
}
