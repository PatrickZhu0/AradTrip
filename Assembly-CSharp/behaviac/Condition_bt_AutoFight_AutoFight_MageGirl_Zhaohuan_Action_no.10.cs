using System;

namespace behaviac
{
	// Token: 0x02002754 RID: 10068
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node58 : Condition
	{
		// Token: 0x060137E9 RID: 79849 RVA: 0x005CF7C9 File Offset: 0x005CDBC9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node58()
		{
			this.opl_p0 = 2118;
		}

		// Token: 0x060137EA RID: 79850 RVA: 0x005CF7DC File Offset: 0x005CDBDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D247 RID: 53831
		private int opl_p0;
	}
}
