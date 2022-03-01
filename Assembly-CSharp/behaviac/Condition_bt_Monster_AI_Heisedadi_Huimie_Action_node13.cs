using System;

namespace behaviac
{
	// Token: 0x02003417 RID: 13335
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node13 : Condition
	{
		// Token: 0x0601507F RID: 86143 RVA: 0x00655E99 File Offset: 0x00654299
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node13()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x06015080 RID: 86144 RVA: 0x00655ED0 File Offset: 0x006542D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E953 RID: 59731
		private int opl_p0;

		// Token: 0x0400E954 RID: 59732
		private int opl_p1;

		// Token: 0x0400E955 RID: 59733
		private int opl_p2;

		// Token: 0x0400E956 RID: 59734
		private int opl_p3;
	}
}
