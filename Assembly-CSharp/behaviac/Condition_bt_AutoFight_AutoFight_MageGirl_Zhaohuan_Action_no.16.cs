using System;

namespace behaviac
{
	// Token: 0x0200275D RID: 10077
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node66 : Condition
	{
		// Token: 0x060137FB RID: 79867 RVA: 0x005CFC0D File Offset: 0x005CE00D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node66()
		{
			this.opl_p0 = 2107;
		}

		// Token: 0x060137FC RID: 79868 RVA: 0x005CFC20 File Offset: 0x005CE020
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D25C RID: 53852
		private int opl_p0;
	}
}
