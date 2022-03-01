using System;

namespace behaviac
{
	// Token: 0x02003FEC RID: 16364
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node6 : Condition
	{
		// Token: 0x0601673E RID: 91966 RVA: 0x006CB749 File Offset: 0x006C9B49
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node6()
		{
			this.opl_p0 = 5354;
		}

		// Token: 0x0601673F RID: 91967 RVA: 0x006CB75C File Offset: 0x006C9B5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF90 RID: 65424
		private int opl_p0;
	}
}
