using System;

namespace behaviac
{
	// Token: 0x02001F07 RID: 7943
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node23 : Condition
	{
		// Token: 0x060127B2 RID: 75698 RVA: 0x005682FE File Offset: 0x005666FE
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060127B3 RID: 75699 RVA: 0x00568330 File Offset: 0x00566730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1A7 RID: 49575
		private int opl_p0;

		// Token: 0x0400C1A8 RID: 49576
		private int opl_p1;

		// Token: 0x0400C1A9 RID: 49577
		private int opl_p2;

		// Token: 0x0400C1AA RID: 49578
		private int opl_p3;
	}
}
