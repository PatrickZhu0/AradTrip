using System;

namespace behaviac
{
	// Token: 0x020023A1 RID: 9121
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node34 : Condition
	{
		// Token: 0x060130A8 RID: 77992 RVA: 0x005A2B3B File Offset: 0x005A0F3B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node34()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x060130A9 RID: 77993 RVA: 0x005A2B5C File Offset: 0x005A0F5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CACB RID: 51915
		private BE_Target opl_p0;

		// Token: 0x0400CACC RID: 51916
		private BE_Equal opl_p1;

		// Token: 0x0400CACD RID: 51917
		private int opl_p2;
	}
}
