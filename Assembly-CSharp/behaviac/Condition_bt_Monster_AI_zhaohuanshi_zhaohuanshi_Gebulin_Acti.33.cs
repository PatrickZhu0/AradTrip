using System;

namespace behaviac
{
	// Token: 0x02003FB7 RID: 16311
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node57 : Condition
	{
		// Token: 0x060166D8 RID: 91864 RVA: 0x006C8861 File Offset: 0x006C6C61
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node57()
		{
			this.opl_p0 = 5111;
		}

		// Token: 0x060166D9 RID: 91865 RVA: 0x006C8874 File Offset: 0x006C6C74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF2C RID: 65324
		private int opl_p0;
	}
}
