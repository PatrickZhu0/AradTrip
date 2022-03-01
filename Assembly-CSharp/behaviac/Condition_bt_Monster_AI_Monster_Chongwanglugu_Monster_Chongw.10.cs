using System;

namespace behaviac
{
	// Token: 0x020035FE RID: 13822
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22 : Condition
	{
		// Token: 0x06015422 RID: 87074 RVA: 0x006686D6 File Offset: 0x00666AD6
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015423 RID: 87075 RVA: 0x0066870C File Offset: 0x00666B0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDDA RID: 60890
		private int opl_p0;

		// Token: 0x0400EDDB RID: 60891
		private int opl_p1;

		// Token: 0x0400EDDC RID: 60892
		private int opl_p2;

		// Token: 0x0400EDDD RID: 60893
		private int opl_p3;
	}
}
