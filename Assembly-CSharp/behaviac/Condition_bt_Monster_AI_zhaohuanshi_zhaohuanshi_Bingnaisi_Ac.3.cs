using System;

namespace behaviac
{
	// Token: 0x02003F7B RID: 16251
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node8 : Condition
	{
		// Token: 0x06016662 RID: 91746 RVA: 0x006C69F5 File Offset: 0x006C4DF5
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node8()
		{
			this.opl_p0 = 5354;
		}

		// Token: 0x06016663 RID: 91747 RVA: 0x006C6A08 File Offset: 0x006C4E08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEB8 RID: 65208
		private int opl_p0;
	}
}
