using System;

namespace behaviac
{
	// Token: 0x02002855 RID: 10325
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node93 : Condition
	{
		// Token: 0x060139E8 RID: 80360 RVA: 0x005DA0CB File Offset: 0x005D84CB
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node93()
		{
			this.opl_p0 = 3507;
		}

		// Token: 0x060139E9 RID: 80361 RVA: 0x005DA0E0 File Offset: 0x005D84E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D441 RID: 54337
		private int opl_p0;
	}
}
