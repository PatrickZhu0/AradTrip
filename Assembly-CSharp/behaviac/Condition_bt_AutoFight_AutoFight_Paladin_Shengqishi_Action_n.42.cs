using System;

namespace behaviac
{
	// Token: 0x02002849 RID: 10313
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node10 : Condition
	{
		// Token: 0x060139D0 RID: 80336 RVA: 0x005D9BAF File Offset: 0x005D7FAF
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node10()
		{
			this.opl_p0 = 3705;
		}

		// Token: 0x060139D1 RID: 80337 RVA: 0x005D9BC4 File Offset: 0x005D7FC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D429 RID: 54313
		private int opl_p0;
	}
}
