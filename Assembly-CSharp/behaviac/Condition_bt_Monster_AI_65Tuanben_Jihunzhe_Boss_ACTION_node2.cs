using System;

namespace behaviac
{
	// Token: 0x02002F05 RID: 12037
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node22 : Condition
	{
		// Token: 0x060146E1 RID: 83681 RVA: 0x0062554B File Offset: 0x0062394B
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node22()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060146E2 RID: 83682 RVA: 0x0062556C File Offset: 0x0062396C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E05A RID: 57434
		private HMType opl_p0;

		// Token: 0x0400E05B RID: 57435
		private BE_Operation opl_p1;

		// Token: 0x0400E05C RID: 57436
		private float opl_p2;
	}
}
