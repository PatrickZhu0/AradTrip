using System;

namespace behaviac
{
	// Token: 0x0200360C RID: 13836
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node26 : Condition
	{
		// Token: 0x0601543E RID: 87102 RVA: 0x00668CE7 File Offset: 0x006670E7
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node26()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601543F RID: 87103 RVA: 0x00668D1C File Offset: 0x0066711C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDF9 RID: 60921
		private int opl_p0;

		// Token: 0x0400EDFA RID: 60922
		private int opl_p1;

		// Token: 0x0400EDFB RID: 60923
		private int opl_p2;

		// Token: 0x0400EDFC RID: 60924
		private int opl_p3;
	}
}
