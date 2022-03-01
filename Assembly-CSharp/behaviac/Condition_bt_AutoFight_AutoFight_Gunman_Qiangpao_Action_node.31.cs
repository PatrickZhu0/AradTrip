using System;

namespace behaviac
{
	// Token: 0x02002666 RID: 9830
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node33 : Condition
	{
		// Token: 0x06013611 RID: 79377 RVA: 0x005C462B File Offset: 0x005C2A2B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node33()
		{
			this.opl_p0 = 1202;
		}

		// Token: 0x06013612 RID: 79378 RVA: 0x005C4640 File Offset: 0x005C2A40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D063 RID: 53347
		private int opl_p0;
	}
}
