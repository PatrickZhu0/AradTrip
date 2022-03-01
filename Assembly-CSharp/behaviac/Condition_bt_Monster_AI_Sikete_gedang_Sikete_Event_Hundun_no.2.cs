using System;

namespace behaviac
{
	// Token: 0x02003736 RID: 14134
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node3 : Condition
	{
		// Token: 0x06015677 RID: 87671 RVA: 0x0067539B File Offset: 0x0067379B
		public Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node3()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015678 RID: 87672 RVA: 0x006753CC File Offset: 0x006737CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F044 RID: 61508
		private int opl_p0;

		// Token: 0x0400F045 RID: 61509
		private int opl_p1;

		// Token: 0x0400F046 RID: 61510
		private int opl_p2;

		// Token: 0x0400F047 RID: 61511
		private int opl_p3;
	}
}
