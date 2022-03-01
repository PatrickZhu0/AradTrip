using System;

namespace behaviac
{
	// Token: 0x02003F9D RID: 16285
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node25 : Condition
	{
		// Token: 0x060166A4 RID: 91812 RVA: 0x006C7D66 File Offset: 0x006C6166
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node25()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060166A5 RID: 91813 RVA: 0x006C7D7C File Offset: 0x006C617C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEF7 RID: 65271
		private float opl_p0;
	}
}
