using System;

namespace behaviac
{
	// Token: 0x02003E09 RID: 15881
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node6 : Condition
	{
		// Token: 0x0601639B RID: 91035 RVA: 0x006B81FE File Offset: 0x006B65FE
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node6()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601639C RID: 91036 RVA: 0x006B8234 File Offset: 0x006B6634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC01 RID: 64513
		private int opl_p0;

		// Token: 0x0400FC02 RID: 64514
		private int opl_p1;

		// Token: 0x0400FC03 RID: 64515
		private int opl_p2;

		// Token: 0x0400FC04 RID: 64516
		private int opl_p3;
	}
}
