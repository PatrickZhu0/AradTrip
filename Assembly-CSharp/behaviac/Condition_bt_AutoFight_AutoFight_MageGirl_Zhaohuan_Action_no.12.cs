using System;

namespace behaviac
{
	// Token: 0x02002757 RID: 10071
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node62 : Condition
	{
		// Token: 0x060137EF RID: 79855 RVA: 0x005CF935 File Offset: 0x005CDD35
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node62()
		{
			this.opl_p0 = 2100;
		}

		// Token: 0x060137F0 RID: 79856 RVA: 0x005CF948 File Offset: 0x005CDD48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D24E RID: 53838
		private int opl_p0;
	}
}
