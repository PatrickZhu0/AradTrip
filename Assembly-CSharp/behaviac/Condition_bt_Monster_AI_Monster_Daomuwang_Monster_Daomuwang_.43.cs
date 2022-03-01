using System;

namespace behaviac
{
	// Token: 0x02003656 RID: 13910
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node12 : Condition
	{
		// Token: 0x060154CE RID: 87246 RVA: 0x0066C592 File Offset: 0x0066A992
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node12()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 8000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x060154CF RID: 87247 RVA: 0x0066C5C8 File Offset: 0x0066A9C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE85 RID: 61061
		private int opl_p0;

		// Token: 0x0400EE86 RID: 61062
		private int opl_p1;

		// Token: 0x0400EE87 RID: 61063
		private int opl_p2;

		// Token: 0x0400EE88 RID: 61064
		private int opl_p3;
	}
}
