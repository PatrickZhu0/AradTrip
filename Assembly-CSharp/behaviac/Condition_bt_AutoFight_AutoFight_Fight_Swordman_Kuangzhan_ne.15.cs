using System;

namespace behaviac
{
	// Token: 0x020023A5 RID: 9125
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node29 : Condition
	{
		// Token: 0x060130B0 RID: 78000 RVA: 0x005A30E7 File Offset: 0x005A14E7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node29()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 160900;
		}

		// Token: 0x060130B1 RID: 78001 RVA: 0x005A3108 File Offset: 0x005A1508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAD5 RID: 51925
		private BE_Target opl_p0;

		// Token: 0x0400CAD6 RID: 51926
		private BE_Equal opl_p1;

		// Token: 0x0400CAD7 RID: 51927
		private int opl_p2;
	}
}
