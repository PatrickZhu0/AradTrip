using System;

namespace behaviac
{
	// Token: 0x0200237A RID: 9082
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node34 : Condition
	{
		// Token: 0x0601305B RID: 77915 RVA: 0x005A0AFB File Offset: 0x0059EEFB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node34()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x0601305C RID: 77916 RVA: 0x005A0B10 File Offset: 0x0059EF10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA70 RID: 51824
		private int opl_p0;
	}
}
