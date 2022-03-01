using System;

namespace behaviac
{
	// Token: 0x020027A9 RID: 10153
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node34 : Condition
	{
		// Token: 0x06013892 RID: 80018 RVA: 0x005D2EA3 File Offset: 0x005D12A3
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node34()
		{
			this.opl_p0 = 3511;
		}

		// Token: 0x06013893 RID: 80019 RVA: 0x005D2EB8 File Offset: 0x005D12B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2F2 RID: 54002
		private int opl_p0;
	}
}
