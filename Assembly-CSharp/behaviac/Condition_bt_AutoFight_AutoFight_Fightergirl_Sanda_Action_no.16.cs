using System;

namespace behaviac
{
	// Token: 0x02001F38 RID: 7992
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node67 : Condition
	{
		// Token: 0x06012813 RID: 75795 RVA: 0x0056A7BD File Offset: 0x00568BBD
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node67()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 100;
			this.opl_p2 = 100;
			this.opl_p3 = 100;
		}

		// Token: 0x06012814 RID: 75796 RVA: 0x0056A7E8 File Offset: 0x00568BE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C209 RID: 49673
		private int opl_p0;

		// Token: 0x0400C20A RID: 49674
		private int opl_p1;

		// Token: 0x0400C20B RID: 49675
		private int opl_p2;

		// Token: 0x0400C20C RID: 49676
		private int opl_p3;
	}
}
