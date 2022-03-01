using System;

namespace behaviac
{
	// Token: 0x020024FB RID: 9467
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node5 : Condition
	{
		// Token: 0x06013340 RID: 78656 RVA: 0x005B3791 File Offset: 0x005B1B91
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node5()
		{
			this.opl_p0 = 2512;
		}

		// Token: 0x06013341 RID: 78657 RVA: 0x005B37A4 File Offset: 0x005B1BA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD61 RID: 52577
		private int opl_p0;
	}
}
