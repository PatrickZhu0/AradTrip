using System;

namespace behaviac
{
	// Token: 0x020023A9 RID: 9129
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node56 : Condition
	{
		// Token: 0x060130B8 RID: 78008 RVA: 0x005A36F3 File Offset: 0x005A1AF3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node56()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 160900;
		}

		// Token: 0x060130B9 RID: 78009 RVA: 0x005A3714 File Offset: 0x005A1B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CADF RID: 51935
		private BE_Target opl_p0;

		// Token: 0x0400CAE0 RID: 51936
		private BE_Equal opl_p1;

		// Token: 0x0400CAE1 RID: 51937
		private int opl_p2;
	}
}
