using System;

namespace behaviac
{
	// Token: 0x0200240C RID: 9228
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node6 : Condition
	{
		// Token: 0x06013175 RID: 78197 RVA: 0x005A9784 File Offset: 0x005A7B84
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x06013176 RID: 78198 RVA: 0x005A97A8 File Offset: 0x005A7BA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBA0 RID: 52128
		private BE_Target opl_p0;

		// Token: 0x0400CBA1 RID: 52129
		private BE_Equal opl_p1;

		// Token: 0x0400CBA2 RID: 52130
		private int opl_p2;
	}
}
