using System;

namespace behaviac
{
	// Token: 0x020026A2 RID: 9890
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node28 : Condition
	{
		// Token: 0x06013688 RID: 79496 RVA: 0x005C72A3 File Offset: 0x005C56A3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node28()
		{
			this.opl_p0 = 2103;
		}

		// Token: 0x06013689 RID: 79497 RVA: 0x005C72B8 File Offset: 0x005C56B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0DC RID: 53468
		private int opl_p0;
	}
}
