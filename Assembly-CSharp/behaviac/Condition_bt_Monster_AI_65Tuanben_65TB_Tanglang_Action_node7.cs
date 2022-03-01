using System;

namespace behaviac
{
	// Token: 0x02002C92 RID: 11410
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node7 : Condition
	{
		// Token: 0x0601421B RID: 82459 RVA: 0x0060BC49 File Offset: 0x0060A049
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node7()
		{
			this.opl_p0 = 20752;
		}

		// Token: 0x0601421C RID: 82460 RVA: 0x0060BC5C File Offset: 0x0060A05C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBD8 RID: 56280
		private int opl_p0;
	}
}
