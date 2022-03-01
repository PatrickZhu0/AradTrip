using System;

namespace behaviac
{
	// Token: 0x020027C5 RID: 10181
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node68 : Condition
	{
		// Token: 0x060138C9 RID: 80073 RVA: 0x005D47D7 File Offset: 0x005D2BD7
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node68()
		{
			this.opl_p0 = 3614;
		}

		// Token: 0x060138CA RID: 80074 RVA: 0x005D47EC File Offset: 0x005D2BEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D328 RID: 54056
		private int opl_p0;
	}
}
