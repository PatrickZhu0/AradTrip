using System;

namespace behaviac
{
	// Token: 0x02003CB4 RID: 15540
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node79 : Condition
	{
		// Token: 0x0601610D RID: 90381 RVA: 0x006ABE32 File Offset: 0x006AA232
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node79()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570105;
		}

		// Token: 0x0601610E RID: 90382 RVA: 0x006ABE54 File Offset: 0x006AA254
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9B4 RID: 63924
		private BE_Target opl_p0;

		// Token: 0x0400F9B5 RID: 63925
		private BE_Equal opl_p1;

		// Token: 0x0400F9B6 RID: 63926
		private int opl_p2;
	}
}
