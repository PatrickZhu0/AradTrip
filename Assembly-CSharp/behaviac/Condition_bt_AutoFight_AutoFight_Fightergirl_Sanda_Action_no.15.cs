using System;

namespace behaviac
{
	// Token: 0x02001F37 RID: 7991
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node46 : Condition
	{
		// Token: 0x06012811 RID: 75793 RVA: 0x0056A743 File Offset: 0x00568B43
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node46()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012812 RID: 75794 RVA: 0x0056A778 File Offset: 0x00568B78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C205 RID: 49669
		private int opl_p0;

		// Token: 0x0400C206 RID: 49670
		private int opl_p1;

		// Token: 0x0400C207 RID: 49671
		private int opl_p2;

		// Token: 0x0400C208 RID: 49672
		private int opl_p3;
	}
}
