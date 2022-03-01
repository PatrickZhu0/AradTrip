using System;

namespace behaviac
{
	// Token: 0x02002646 RID: 9798
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node99 : Condition
	{
		// Token: 0x060135D1 RID: 79313 RVA: 0x005C38B7 File Offset: 0x005C1CB7
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node99()
		{
			this.opl_p0 = 1209;
		}

		// Token: 0x060135D2 RID: 79314 RVA: 0x005C38CC File Offset: 0x005C1CCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D021 RID: 53281
		private int opl_p0;
	}
}
