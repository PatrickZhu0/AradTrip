using System;

namespace behaviac
{
	// Token: 0x02002D7B RID: 11643
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node32 : Condition
	{
		// Token: 0x060143D8 RID: 82904 RVA: 0x0061466F File Offset: 0x00612A6F
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node32()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060143D9 RID: 82905 RVA: 0x00614690 File Offset: 0x00612A90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDA7 RID: 56743
		private HMType opl_p0;

		// Token: 0x0400DDA8 RID: 56744
		private BE_Operation opl_p1;

		// Token: 0x0400DDA9 RID: 56745
		private float opl_p2;
	}
}
