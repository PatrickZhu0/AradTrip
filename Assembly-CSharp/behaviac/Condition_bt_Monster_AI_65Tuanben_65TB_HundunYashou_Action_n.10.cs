using System;

namespace behaviac
{
	// Token: 0x02002B91 RID: 11153
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node7 : Condition
	{
		// Token: 0x0601402E RID: 81966 RVA: 0x006022F9 File Offset: 0x006006F9
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node7()
		{
			this.opl_p0 = 20766;
		}

		// Token: 0x0601402F RID: 81967 RVA: 0x0060230C File Offset: 0x0060070C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA25 RID: 55845
		private int opl_p0;
	}
}
