using System;

namespace behaviac
{
	// Token: 0x0200313E RID: 12606
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node15 : Condition
	{
		// Token: 0x06014B1F RID: 84767 RVA: 0x0063B609 File Offset: 0x00639A09
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node15()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014B20 RID: 84768 RVA: 0x0063B62C File Offset: 0x00639A2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E498 RID: 58520
		private HMType opl_p0;

		// Token: 0x0400E499 RID: 58521
		private BE_Operation opl_p1;

		// Token: 0x0400E49A RID: 58522
		private float opl_p2;
	}
}
