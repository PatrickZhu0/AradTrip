using System;

namespace behaviac
{
	// Token: 0x02002EBF RID: 11967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node48 : Condition
	{
		// Token: 0x06014658 RID: 83544 RVA: 0x0062239B File Offset: 0x0062079B
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node48()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x06014659 RID: 83545 RVA: 0x006223BC File Offset: 0x006207BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFC7 RID: 57287
		private HMType opl_p0;

		// Token: 0x0400DFC8 RID: 57288
		private BE_Operation opl_p1;

		// Token: 0x0400DFC9 RID: 57289
		private float opl_p2;
	}
}
