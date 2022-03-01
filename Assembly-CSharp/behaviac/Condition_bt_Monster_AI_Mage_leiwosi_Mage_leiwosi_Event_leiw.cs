using System;

namespace behaviac
{
	// Token: 0x020035AD RID: 13741
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2 : Condition
	{
		// Token: 0x06015388 RID: 86920 RVA: 0x00665781 File Offset: 0x00663B81
		public Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015389 RID: 86921 RVA: 0x006657B8 File Offset: 0x00663BB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED54 RID: 60756
		private int opl_p0;

		// Token: 0x0400ED55 RID: 60757
		private int opl_p1;

		// Token: 0x0400ED56 RID: 60758
		private int opl_p2;

		// Token: 0x0400ED57 RID: 60759
		private int opl_p3;
	}
}
