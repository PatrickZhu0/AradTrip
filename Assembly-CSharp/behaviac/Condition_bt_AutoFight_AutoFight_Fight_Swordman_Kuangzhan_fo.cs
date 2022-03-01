using System;

namespace behaviac
{
	// Token: 0x02002334 RID: 9012
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node6 : Condition
	{
		// Token: 0x06012FD9 RID: 77785 RVA: 0x0059DEFC File Offset: 0x0059C2FC
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x06012FDA RID: 77786 RVA: 0x0059DF20 File Offset: 0x0059C320
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9F1 RID: 51697
		private BE_Target opl_p0;

		// Token: 0x0400C9F2 RID: 51698
		private BE_Equal opl_p1;

		// Token: 0x0400C9F3 RID: 51699
		private int opl_p2;
	}
}
