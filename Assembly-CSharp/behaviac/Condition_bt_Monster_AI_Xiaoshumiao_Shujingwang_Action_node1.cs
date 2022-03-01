using System;

namespace behaviac
{
	// Token: 0x02003E11 RID: 15889
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node16 : Condition
	{
		// Token: 0x060163AB RID: 91051 RVA: 0x006B8566 File Offset: 0x006B6966
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node16()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 3000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060163AC RID: 91052 RVA: 0x006B859C File Offset: 0x006B699C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC11 RID: 64529
		private int opl_p0;

		// Token: 0x0400FC12 RID: 64530
		private int opl_p1;

		// Token: 0x0400FC13 RID: 64531
		private int opl_p2;

		// Token: 0x0400FC14 RID: 64532
		private int opl_p3;
	}
}
