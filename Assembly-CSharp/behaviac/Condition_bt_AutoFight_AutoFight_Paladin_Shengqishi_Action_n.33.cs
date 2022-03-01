using System;

namespace behaviac
{
	// Token: 0x0200283D RID: 10301
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node15 : Condition
	{
		// Token: 0x060139B8 RID: 80312 RVA: 0x005D9693 File Offset: 0x005D7A93
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node15()
		{
			this.opl_p0 = 3707;
		}

		// Token: 0x060139B9 RID: 80313 RVA: 0x005D96A8 File Offset: 0x005D7AA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D411 RID: 54289
		private int opl_p0;
	}
}
