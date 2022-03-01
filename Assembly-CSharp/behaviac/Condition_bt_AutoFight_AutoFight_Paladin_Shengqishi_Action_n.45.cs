using System;

namespace behaviac
{
	// Token: 0x0200284D RID: 10317
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node83 : Condition
	{
		// Token: 0x060139D8 RID: 80344 RVA: 0x005D9D63 File Offset: 0x005D8163
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node83()
		{
			this.opl_p0 = 3505;
		}

		// Token: 0x060139D9 RID: 80345 RVA: 0x005D9D78 File Offset: 0x005D8178
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D431 RID: 54321
		private int opl_p0;
	}
}
