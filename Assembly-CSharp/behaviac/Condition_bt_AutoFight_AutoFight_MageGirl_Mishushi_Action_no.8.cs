using System;

namespace behaviac
{
	// Token: 0x020026B8 RID: 9912
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node80 : Condition
	{
		// Token: 0x060136B3 RID: 79539 RVA: 0x005C8973 File Offset: 0x005C6D73
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node80()
		{
			this.opl_p0 = 2206;
		}

		// Token: 0x060136B4 RID: 79540 RVA: 0x005C8988 File Offset: 0x005C6D88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D109 RID: 53513
		private int opl_p0;
	}
}
