using System;

namespace behaviac
{
	// Token: 0x0200275A RID: 10074
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node3 : Condition
	{
		// Token: 0x060137F5 RID: 79861 RVA: 0x005CFAA1 File Offset: 0x005CDEA1
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node3()
		{
			this.opl_p0 = 2111;
		}

		// Token: 0x060137F6 RID: 79862 RVA: 0x005CFAB4 File Offset: 0x005CDEB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D255 RID: 53845
		private int opl_p0;
	}
}
