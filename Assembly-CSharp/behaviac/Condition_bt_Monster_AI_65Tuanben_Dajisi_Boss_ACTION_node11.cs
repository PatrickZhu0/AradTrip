using System;

namespace behaviac
{
	// Token: 0x02002D77 RID: 11639
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node11 : Condition
	{
		// Token: 0x060143D0 RID: 82896 RVA: 0x006144BB File Offset: 0x006128BB
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node11()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.15f;
		}

		// Token: 0x060143D1 RID: 82897 RVA: 0x006144DC File Offset: 0x006128DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD9E RID: 56734
		private HMType opl_p0;

		// Token: 0x0400DD9F RID: 56735
		private BE_Operation opl_p1;

		// Token: 0x0400DDA0 RID: 56736
		private float opl_p2;
	}
}
