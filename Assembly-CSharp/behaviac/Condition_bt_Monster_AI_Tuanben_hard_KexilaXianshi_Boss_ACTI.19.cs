using System;

namespace behaviac
{
	// Token: 0x02003C80 RID: 15488
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node79 : Condition
	{
		// Token: 0x060160A7 RID: 90279 RVA: 0x006A91E6 File Offset: 0x006A75E6
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node79()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570105;
		}

		// Token: 0x060160A8 RID: 90280 RVA: 0x006A9208 File Offset: 0x006A7608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F93C RID: 63804
		private BE_Target opl_p0;

		// Token: 0x0400F93D RID: 63805
		private BE_Equal opl_p1;

		// Token: 0x0400F93E RID: 63806
		private int opl_p2;
	}
}
