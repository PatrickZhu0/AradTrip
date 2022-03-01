using System;

namespace behaviac
{
	// Token: 0x02002976 RID: 10614
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node62 : Condition
	{
		// Token: 0x06013C21 RID: 80929 RVA: 0x005E80BF File Offset: 0x005E64BF
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node62()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x06013C22 RID: 80930 RVA: 0x005E80E0 File Offset: 0x005E64E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D685 RID: 54917
		private BE_Target opl_p0;

		// Token: 0x0400D686 RID: 54918
		private BE_Equal opl_p1;

		// Token: 0x0400D687 RID: 54919
		private int opl_p2;
	}
}
