using System;

namespace behaviac
{
	// Token: 0x0200274B RID: 10059
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node99 : Condition
	{
		// Token: 0x060137D7 RID: 79831 RVA: 0x005CF383 File Offset: 0x005CD783
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node99()
		{
			this.opl_p0 = 2113;
		}

		// Token: 0x060137D8 RID: 79832 RVA: 0x005CF398 File Offset: 0x005CD798
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D232 RID: 53810
		private int opl_p0;
	}
}
