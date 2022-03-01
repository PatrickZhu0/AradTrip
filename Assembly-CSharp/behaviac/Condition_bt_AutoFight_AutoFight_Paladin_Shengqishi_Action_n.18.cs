using System;

namespace behaviac
{
	// Token: 0x02002829 RID: 10281
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node73 : Condition
	{
		// Token: 0x06013990 RID: 80272 RVA: 0x005D8E0F File Offset: 0x005D720F
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node73()
		{
			this.opl_p0 = 3708;
		}

		// Token: 0x06013991 RID: 80273 RVA: 0x005D8E24 File Offset: 0x005D7224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3E9 RID: 54249
		private int opl_p0;
	}
}
