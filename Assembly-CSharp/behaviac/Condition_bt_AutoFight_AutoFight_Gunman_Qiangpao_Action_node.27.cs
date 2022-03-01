using System;

namespace behaviac
{
	// Token: 0x02002661 RID: 9825
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node28 : Condition
	{
		// Token: 0x06013607 RID: 79367 RVA: 0x005C441B File Offset: 0x005C281B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node28()
		{
			this.opl_p0 = 1200;
		}

		// Token: 0x06013608 RID: 79368 RVA: 0x005C4430 File Offset: 0x005C2830
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D058 RID: 53336
		private int opl_p0;
	}
}
