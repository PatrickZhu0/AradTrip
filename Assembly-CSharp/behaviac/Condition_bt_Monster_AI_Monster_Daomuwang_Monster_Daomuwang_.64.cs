using System;

namespace behaviac
{
	// Token: 0x02003673 RID: 13939
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node7 : Condition
	{
		// Token: 0x06015507 RID: 87303 RVA: 0x0066D912 File Offset: 0x0066BD12
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node7()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06015508 RID: 87304 RVA: 0x0066D948 File Offset: 0x0066BD48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEBD RID: 61117
		private int opl_p0;

		// Token: 0x0400EEBE RID: 61118
		private int opl_p1;

		// Token: 0x0400EEBF RID: 61119
		private int opl_p2;

		// Token: 0x0400EEC0 RID: 61120
		private int opl_p3;
	}
}
