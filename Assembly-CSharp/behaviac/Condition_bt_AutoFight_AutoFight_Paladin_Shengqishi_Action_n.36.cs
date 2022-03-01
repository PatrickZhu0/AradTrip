using System;

namespace behaviac
{
	// Token: 0x02002841 RID: 10305
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node30 : Condition
	{
		// Token: 0x060139C0 RID: 80320 RVA: 0x005D9847 File Offset: 0x005D7C47
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node30()
		{
			this.opl_p0 = 3713;
		}

		// Token: 0x060139C1 RID: 80321 RVA: 0x005D985C File Offset: 0x005D7C5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D419 RID: 54297
		private int opl_p0;
	}
}
