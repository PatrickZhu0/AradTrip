using System;

namespace behaviac
{
	// Token: 0x02002CC5 RID: 11461
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node14 : Condition
	{
		// Token: 0x0601427E RID: 82558 RVA: 0x0060DB5D File Offset: 0x0060BF5D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node14()
		{
			this.opl_p0 = 20753;
		}

		// Token: 0x0601427F RID: 82559 RVA: 0x0060DB70 File Offset: 0x0060BF70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC32 RID: 56370
		private int opl_p0;
	}
}
