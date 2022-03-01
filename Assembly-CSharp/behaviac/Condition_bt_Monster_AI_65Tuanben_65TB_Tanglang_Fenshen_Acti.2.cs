using System;

namespace behaviac
{
	// Token: 0x02002CBD RID: 11453
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2 : Condition
	{
		// Token: 0x0601426E RID: 82542 RVA: 0x0060D85D File Offset: 0x0060BC5D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2()
		{
			this.opl_p0 = 20750;
		}

		// Token: 0x0601426F RID: 82543 RVA: 0x0060D870 File Offset: 0x0060BC70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC24 RID: 56356
		private int opl_p0;
	}
}
