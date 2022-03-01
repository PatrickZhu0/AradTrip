using System;

namespace behaviac
{
	// Token: 0x02002D97 RID: 11671
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node27 : Condition
	{
		// Token: 0x0601440F RID: 82959 RVA: 0x00615AB3 File Offset: 0x00613EB3
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node27()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x06014410 RID: 82960 RVA: 0x00615AD4 File Offset: 0x00613ED4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDD7 RID: 56791
		private HMType opl_p0;

		// Token: 0x0400DDD8 RID: 56792
		private BE_Operation opl_p1;

		// Token: 0x0400DDD9 RID: 56793
		private float opl_p2;
	}
}
