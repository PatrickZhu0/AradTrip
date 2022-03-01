using System;

namespace behaviac
{
	// Token: 0x02002677 RID: 9847
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node4 : Condition
	{
		// Token: 0x06013633 RID: 79411 RVA: 0x005C4D5F File Offset: 0x005C315F
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node4()
		{
			this.opl_p0 = 1013;
		}

		// Token: 0x06013634 RID: 79412 RVA: 0x005C4D74 File Offset: 0x005C3174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D086 RID: 53382
		private int opl_p0;
	}
}
