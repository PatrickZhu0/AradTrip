using System;

namespace behaviac
{
	// Token: 0x0200266B RID: 9835
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node5 : Condition
	{
		// Token: 0x0601361B RID: 79387 RVA: 0x005C483B File Offset: 0x005C2C3B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node5()
		{
			this.opl_p0 = 1011;
		}

		// Token: 0x0601361C RID: 79388 RVA: 0x005C4850 File Offset: 0x005C2C50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D06E RID: 53358
		private int opl_p0;
	}
}
