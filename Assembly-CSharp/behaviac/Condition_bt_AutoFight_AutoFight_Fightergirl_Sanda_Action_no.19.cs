using System;

namespace behaviac
{
	// Token: 0x02001F3C RID: 7996
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node86 : Condition
	{
		// Token: 0x0601281B RID: 75803 RVA: 0x0056A96B File Offset: 0x00568D6B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node86()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601281C RID: 75804 RVA: 0x0056A9A0 File Offset: 0x00568DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C211 RID: 49681
		private int opl_p0;

		// Token: 0x0400C212 RID: 49682
		private int opl_p1;

		// Token: 0x0400C213 RID: 49683
		private int opl_p2;

		// Token: 0x0400C214 RID: 49684
		private int opl_p3;
	}
}
