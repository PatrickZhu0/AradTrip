using System;

namespace behaviac
{
	// Token: 0x02002769 RID: 10089
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node46 : Condition
	{
		// Token: 0x06013813 RID: 79891 RVA: 0x005D0127 File Offset: 0x005CE527
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node46()
		{
			this.opl_p0 = 2003;
		}

		// Token: 0x06013814 RID: 79892 RVA: 0x005D013C File Offset: 0x005CE53C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D274 RID: 53876
		private int opl_p0;
	}
}
