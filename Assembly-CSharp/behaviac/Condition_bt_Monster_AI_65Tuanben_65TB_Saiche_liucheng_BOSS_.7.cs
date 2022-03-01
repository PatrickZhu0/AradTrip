using System;

namespace behaviac
{
	// Token: 0x02002BDF RID: 11231
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node0 : Condition
	{
		// Token: 0x060140BD RID: 82109 RVA: 0x006051E1 File Offset: 0x006035E1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node0()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x060140BE RID: 82110 RVA: 0x00605204 File Offset: 0x00603604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA9E RID: 55966
		private HMType opl_p0;

		// Token: 0x0400DA9F RID: 55967
		private BE_Operation opl_p1;

		// Token: 0x0400DAA0 RID: 55968
		private float opl_p2;
	}
}
