using System;

namespace behaviac
{
	// Token: 0x0200274E RID: 10062
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node50 : Condition
	{
		// Token: 0x060137DD RID: 79837 RVA: 0x005CF4F1 File Offset: 0x005CD8F1
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node50()
		{
			this.opl_p0 = 2109;
		}

		// Token: 0x060137DE RID: 79838 RVA: 0x005CF504 File Offset: 0x005CD904
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D239 RID: 53817
		private int opl_p0;
	}
}
