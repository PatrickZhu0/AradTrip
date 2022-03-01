using System;

namespace behaviac
{
	// Token: 0x02002845 RID: 10309
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node25 : Condition
	{
		// Token: 0x060139C8 RID: 80328 RVA: 0x005D99FB File Offset: 0x005D7DFB
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node25()
		{
			this.opl_p0 = 3711;
		}

		// Token: 0x060139C9 RID: 80329 RVA: 0x005D9A10 File Offset: 0x005D7E10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D421 RID: 54305
		private int opl_p0;
	}
}
