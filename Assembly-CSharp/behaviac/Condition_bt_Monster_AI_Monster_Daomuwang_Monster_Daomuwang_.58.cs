using System;

namespace behaviac
{
	// Token: 0x0200366B RID: 13931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node2 : Condition
	{
		// Token: 0x060154F7 RID: 87287 RVA: 0x0066D5AA File Offset: 0x0066B9AA
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060154F8 RID: 87288 RVA: 0x0066D5E0 File Offset: 0x0066B9E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEAD RID: 61101
		private int opl_p0;

		// Token: 0x0400EEAE RID: 61102
		private int opl_p1;

		// Token: 0x0400EEAF RID: 61103
		private int opl_p2;

		// Token: 0x0400EEB0 RID: 61104
		private int opl_p3;
	}
}
