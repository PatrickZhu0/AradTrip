using System;

namespace behaviac
{
	// Token: 0x02002364 RID: 9060
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node6 : Condition
	{
		// Token: 0x06013033 RID: 77875 RVA: 0x005A01C8 File Offset: 0x0059E5C8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x06013034 RID: 77876 RVA: 0x005A01EC File Offset: 0x0059E5EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA4A RID: 51786
		private BE_Target opl_p0;

		// Token: 0x0400CA4B RID: 51787
		private BE_Equal opl_p1;

		// Token: 0x0400CA4C RID: 51788
		private int opl_p2;
	}
}
