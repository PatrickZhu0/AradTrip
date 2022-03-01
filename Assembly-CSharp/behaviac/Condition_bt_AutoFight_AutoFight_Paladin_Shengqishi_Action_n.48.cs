using System;

namespace behaviac
{
	// Token: 0x02002851 RID: 10321
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node88 : Condition
	{
		// Token: 0x060139E0 RID: 80352 RVA: 0x005D9F17 File Offset: 0x005D8317
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node88()
		{
			this.opl_p0 = 3504;
		}

		// Token: 0x060139E1 RID: 80353 RVA: 0x005D9F2C File Offset: 0x005D832C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D439 RID: 54329
		private int opl_p0;
	}
}
