using System;

namespace behaviac
{
	// Token: 0x02003F95 RID: 16277
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node15 : Condition
	{
		// Token: 0x06016694 RID: 91796 RVA: 0x006C79FE File Offset: 0x006C5DFE
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node15()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06016695 RID: 91797 RVA: 0x006C7A14 File Offset: 0x006C5E14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEE7 RID: 65255
		private float opl_p0;
	}
}
