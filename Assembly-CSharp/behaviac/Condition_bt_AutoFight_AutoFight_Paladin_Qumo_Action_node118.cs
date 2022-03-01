using System;

namespace behaviac
{
	// Token: 0x020027D9 RID: 10201
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node118 : Condition
	{
		// Token: 0x060138F1 RID: 80113 RVA: 0x005D505B File Offset: 0x005D345B
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node118()
		{
			this.opl_p0 = 3608;
		}

		// Token: 0x060138F2 RID: 80114 RVA: 0x005D5070 File Offset: 0x005D3470
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D350 RID: 54096
		private int opl_p0;
	}
}
