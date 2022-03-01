using System;

namespace behaviac
{
	// Token: 0x02001EEA RID: 7914
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node23 : Condition
	{
		// Token: 0x06012779 RID: 75641 RVA: 0x00566C02 File Offset: 0x00565002
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node23()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 3;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601277A RID: 75642 RVA: 0x00566C34 File Offset: 0x00565034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C16D RID: 49517
		private int opl_p0;

		// Token: 0x0400C16E RID: 49518
		private int opl_p1;

		// Token: 0x0400C16F RID: 49519
		private int opl_p2;

		// Token: 0x0400C170 RID: 49520
		private int opl_p3;
	}
}
