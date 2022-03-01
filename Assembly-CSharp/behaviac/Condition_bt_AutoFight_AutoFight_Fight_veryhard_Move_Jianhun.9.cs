using System;

namespace behaviac
{
	// Token: 0x0200248C RID: 9356
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7 : Condition
	{
		// Token: 0x06013265 RID: 78437 RVA: 0x005AEE79 File Offset: 0x005AD279
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06013266 RID: 78438 RVA: 0x005AEE98 File Offset: 0x005AD298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC80 RID: 52352
		private BE_Target opl_p0;

		// Token: 0x0400CC81 RID: 52353
		private BE_Equal opl_p1;

		// Token: 0x0400CC82 RID: 52354
		private BE_State opl_p2;
	}
}
