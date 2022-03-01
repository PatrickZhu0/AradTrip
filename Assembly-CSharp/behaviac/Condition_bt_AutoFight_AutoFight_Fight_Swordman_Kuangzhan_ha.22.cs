using System;

namespace behaviac
{
	// Token: 0x02002383 RID: 9091
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node45 : Condition
	{
		// Token: 0x0601306D RID: 77933 RVA: 0x005A0EC5 File Offset: 0x0059F2C5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node45()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x0601306E RID: 77934 RVA: 0x005A0ED8 File Offset: 0x0059F2D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA83 RID: 51843
		private int opl_p0;
	}
}
