using System;

namespace behaviac
{
	// Token: 0x020027E5 RID: 10213
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node63 : Condition
	{
		// Token: 0x06013909 RID: 80137 RVA: 0x005D5577 File Offset: 0x005D3977
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node63()
		{
			this.opl_p0 = 3613;
		}

		// Token: 0x0601390A RID: 80138 RVA: 0x005D558C File Offset: 0x005D398C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D368 RID: 54120
		private int opl_p0;
	}
}
