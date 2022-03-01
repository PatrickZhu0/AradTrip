using System;

namespace behaviac
{
	// Token: 0x020027E1 RID: 10209
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node58 : Condition
	{
		// Token: 0x06013901 RID: 80129 RVA: 0x005D53C3 File Offset: 0x005D37C3
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node58()
		{
			this.opl_p0 = 3611;
		}

		// Token: 0x06013902 RID: 80130 RVA: 0x005D53D8 File Offset: 0x005D37D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D360 RID: 54112
		private int opl_p0;
	}
}
