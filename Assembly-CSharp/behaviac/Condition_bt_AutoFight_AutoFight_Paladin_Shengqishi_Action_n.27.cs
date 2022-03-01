using System;

namespace behaviac
{
	// Token: 0x02002835 RID: 10293
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node35 : Condition
	{
		// Token: 0x060139A8 RID: 80296 RVA: 0x005D932B File Offset: 0x005D772B
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node35()
		{
			this.opl_p0 = 3714;
		}

		// Token: 0x060139A9 RID: 80297 RVA: 0x005D9340 File Offset: 0x005D7740
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D401 RID: 54273
		private int opl_p0;
	}
}
