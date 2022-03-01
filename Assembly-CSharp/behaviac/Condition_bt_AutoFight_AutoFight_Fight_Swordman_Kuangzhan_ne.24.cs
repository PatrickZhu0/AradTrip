using System;

namespace behaviac
{
	// Token: 0x020023B1 RID: 9137
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node71 : Condition
	{
		// Token: 0x060130C8 RID: 78024 RVA: 0x005A41FB File Offset: 0x005A25FB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node71()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x060130C9 RID: 78025 RVA: 0x005A421C File Offset: 0x005A261C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAF3 RID: 51955
		private BE_Target opl_p0;

		// Token: 0x0400CAF4 RID: 51956
		private BE_Equal opl_p1;

		// Token: 0x0400CAF5 RID: 51957
		private int opl_p2;
	}
}
