using System;

namespace behaviac
{
	// Token: 0x020029DE RID: 10718
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node13 : Condition
	{
		// Token: 0x06013CEF RID: 81135 RVA: 0x005EDE19 File Offset: 0x005EC219
		public Condition_bt_BOSS_BOSS20_4_Action_node13()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 25f;
		}

		// Token: 0x06013CF0 RID: 81136 RVA: 0x005EDE3C File Offset: 0x005EC23C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D762 RID: 55138
		private HMType opl_p0;

		// Token: 0x0400D763 RID: 55139
		private BE_Operation opl_p1;

		// Token: 0x0400D764 RID: 55140
		private float opl_p2;
	}
}
