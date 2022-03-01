using System;

namespace behaviac
{
	// Token: 0x0200264F RID: 9807
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node7 : Condition
	{
		// Token: 0x060135E3 RID: 79331 RVA: 0x005C3C57 File Offset: 0x005C2057
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node7()
		{
			this.opl_p0 = 1010;
		}

		// Token: 0x060135E4 RID: 79332 RVA: 0x005C3C6C File Offset: 0x005C206C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D033 RID: 53299
		private int opl_p0;
	}
}
