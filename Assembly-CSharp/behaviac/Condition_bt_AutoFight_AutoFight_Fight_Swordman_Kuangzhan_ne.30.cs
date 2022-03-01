using System;

namespace behaviac
{
	// Token: 0x020023B9 RID: 9145
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node46 : Condition
	{
		// Token: 0x060130D8 RID: 78040 RVA: 0x005A4C57 File Offset: 0x005A3057
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node46()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 160900;
		}

		// Token: 0x060130D9 RID: 78041 RVA: 0x005A4C78 File Offset: 0x005A3078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB07 RID: 51975
		private BE_Target opl_p0;

		// Token: 0x0400CB08 RID: 51976
		private BE_Equal opl_p1;

		// Token: 0x0400CB09 RID: 51977
		private int opl_p2;
	}
}
