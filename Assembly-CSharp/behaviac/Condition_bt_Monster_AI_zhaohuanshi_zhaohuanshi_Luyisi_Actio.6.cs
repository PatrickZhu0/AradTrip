using System;

namespace behaviac
{
	// Token: 0x02003FD3 RID: 16339
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node14 : Condition
	{
		// Token: 0x0601670E RID: 91918 RVA: 0x006CA5C9 File Offset: 0x006C89C9
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node14()
		{
			this.opl_p0 = 5023;
		}

		// Token: 0x0601670F RID: 91919 RVA: 0x006CA5DC File Offset: 0x006C89DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF61 RID: 65377
		private int opl_p0;
	}
}
