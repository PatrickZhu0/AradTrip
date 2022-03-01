using System;

namespace behaviac
{
	// Token: 0x02003F93 RID: 16275
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node12 : Condition
	{
		// Token: 0x06016690 RID: 91792 RVA: 0x006C790D File Offset: 0x006C5D0D
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node12()
		{
			this.opl_p0 = 5110;
		}

		// Token: 0x06016691 RID: 91793 RVA: 0x006C7920 File Offset: 0x006C5D20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEE4 RID: 65252
		private int opl_p0;
	}
}
