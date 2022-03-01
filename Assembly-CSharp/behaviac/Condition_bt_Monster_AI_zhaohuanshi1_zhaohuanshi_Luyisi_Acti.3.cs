using System;

namespace behaviac
{
	// Token: 0x02004078 RID: 16504
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node10 : Condition
	{
		// Token: 0x0601684D RID: 92237 RVA: 0x006D15F1 File Offset: 0x006CF9F1
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node10()
		{
			this.opl_p0 = 5022;
		}

		// Token: 0x0601684E RID: 92238 RVA: 0x006D1604 File Offset: 0x006CFA04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010098 RID: 65688
		private int opl_p0;
	}
}
