using System;

namespace behaviac
{
	// Token: 0x020035A1 RID: 13729
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node5 : Condition
	{
		// Token: 0x06015371 RID: 86897 RVA: 0x00664FCF File Offset: 0x006633CF
		public Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015372 RID: 86898 RVA: 0x00665000 File Offset: 0x00663400
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED39 RID: 60729
		private int opl_p0;

		// Token: 0x0400ED3A RID: 60730
		private int opl_p1;

		// Token: 0x0400ED3B RID: 60731
		private int opl_p2;

		// Token: 0x0400ED3C RID: 60732
		private int opl_p3;
	}
}
