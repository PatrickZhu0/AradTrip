using System;

namespace behaviac
{
	// Token: 0x02002D7A RID: 11642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node12 : Condition
	{
		// Token: 0x060143D6 RID: 82902 RVA: 0x0061460E File Offset: 0x00612A0E
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node12()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.15f;
		}

		// Token: 0x060143D7 RID: 82903 RVA: 0x00614630 File Offset: 0x00612A30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDA4 RID: 56740
		private HMType opl_p0;

		// Token: 0x0400DDA5 RID: 56741
		private BE_Operation opl_p1;

		// Token: 0x0400DDA6 RID: 56742
		private float opl_p2;
	}
}
