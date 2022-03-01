using System;

namespace behaviac
{
	// Token: 0x020027CD RID: 10189
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node29 : Condition
	{
		// Token: 0x060138D9 RID: 80089 RVA: 0x005D4B3F File Offset: 0x005D2F3F
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node29()
		{
			this.opl_p0 = 3600;
		}

		// Token: 0x060138DA RID: 80090 RVA: 0x005D4B54 File Offset: 0x005D2F54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D338 RID: 54072
		private int opl_p0;
	}
}
