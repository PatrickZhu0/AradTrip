using System;

namespace behaviac
{
	// Token: 0x02002C03 RID: 11267
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node101 : Condition
	{
		// Token: 0x06014105 RID: 82181 RVA: 0x00605C21 File Offset: 0x00604021
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node101()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x06014106 RID: 82182 RVA: 0x00605C44 File Offset: 0x00604044
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAE2 RID: 56034
		private HMType opl_p0;

		// Token: 0x0400DAE3 RID: 56035
		private BE_Operation opl_p1;

		// Token: 0x0400DAE4 RID: 56036
		private float opl_p2;
	}
}
