using System;

namespace behaviac
{
	// Token: 0x0200298A RID: 10634
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node32 : Condition
	{
		// Token: 0x06013C48 RID: 80968 RVA: 0x005E9CAB File Offset: 0x005E80AB
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node32()
		{
			this.opl_p0 = 1804;
		}

		// Token: 0x06013C49 RID: 80969 RVA: 0x005E9CC0 File Offset: 0x005E80C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6B2 RID: 54962
		private int opl_p0;
	}
}
