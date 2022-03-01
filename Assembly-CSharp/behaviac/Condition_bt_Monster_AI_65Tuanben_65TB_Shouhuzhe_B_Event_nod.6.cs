using System;

namespace behaviac
{
	// Token: 0x02002C6F RID: 11375
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node4 : Condition
	{
		// Token: 0x060141D7 RID: 82391 RVA: 0x0060A75D File Offset: 0x00608B5D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x060141D8 RID: 82392 RVA: 0x0060A780 File Offset: 0x00608B80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB99 RID: 56217
		private HMType opl_p0;

		// Token: 0x0400DB9A RID: 56218
		private BE_Operation opl_p1;

		// Token: 0x0400DB9B RID: 56219
		private float opl_p2;
	}
}
