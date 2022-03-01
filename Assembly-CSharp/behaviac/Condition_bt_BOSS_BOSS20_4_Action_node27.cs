using System;

namespace behaviac
{
	// Token: 0x020029E3 RID: 10723
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node27 : Condition
	{
		// Token: 0x06013CF9 RID: 81145 RVA: 0x005EE031 File Offset: 0x005EC431
		public Condition_bt_BOSS_BOSS20_4_Action_node27()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 50f;
		}

		// Token: 0x06013CFA RID: 81146 RVA: 0x005EE054 File Offset: 0x005EC454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D76D RID: 55149
		private HMType opl_p0;

		// Token: 0x0400D76E RID: 55150
		private BE_Operation opl_p1;

		// Token: 0x0400D76F RID: 55151
		private float opl_p2;
	}
}
