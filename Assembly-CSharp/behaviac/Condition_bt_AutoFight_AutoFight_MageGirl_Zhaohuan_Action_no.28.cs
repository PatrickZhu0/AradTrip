using System;

namespace behaviac
{
	// Token: 0x0200276D RID: 10093
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node13 : Condition
	{
		// Token: 0x0601381B RID: 79899 RVA: 0x005D02DB File Offset: 0x005CE6DB
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node13()
		{
			this.opl_p0 = 2009;
		}

		// Token: 0x0601381C RID: 79900 RVA: 0x005D02F0 File Offset: 0x005CE6F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D27C RID: 53884
		private int opl_p0;
	}
}
