using System;

namespace behaviac
{
	// Token: 0x02002732 RID: 10034
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node40 : Condition
	{
		// Token: 0x060137A6 RID: 79782 RVA: 0x005CD497 File Offset: 0x005CB897
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node40()
		{
			this.opl_p0 = 2308;
		}

		// Token: 0x060137A7 RID: 79783 RVA: 0x005CD4AC File Offset: 0x005CB8AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D200 RID: 53760
		private int opl_p0;
	}
}
