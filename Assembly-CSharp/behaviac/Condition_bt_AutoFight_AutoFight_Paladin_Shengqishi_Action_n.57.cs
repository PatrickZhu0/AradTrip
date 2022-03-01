using System;

namespace behaviac
{
	// Token: 0x0200285D RID: 10333
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node108 : Condition
	{
		// Token: 0x060139F8 RID: 80376 RVA: 0x005DA433 File Offset: 0x005D8833
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node108()
		{
			this.opl_p0 = 3511;
		}

		// Token: 0x060139F9 RID: 80377 RVA: 0x005DA448 File Offset: 0x005D8848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D451 RID: 54353
		private int opl_p0;
	}
}
