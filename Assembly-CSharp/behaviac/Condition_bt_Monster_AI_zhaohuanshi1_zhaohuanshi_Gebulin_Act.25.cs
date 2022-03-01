using System;

namespace behaviac
{
	// Token: 0x02004056 RID: 16470
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node45 : Condition
	{
		// Token: 0x0601680B RID: 92171 RVA: 0x006CF612 File Offset: 0x006CDA12
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node45()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601680C RID: 92172 RVA: 0x006CF628 File Offset: 0x006CDA28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010056 RID: 65622
		private float opl_p0;
	}
}
