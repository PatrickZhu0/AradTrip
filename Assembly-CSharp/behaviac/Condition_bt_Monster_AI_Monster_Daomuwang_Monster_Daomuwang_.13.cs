using System;

namespace behaviac
{
	// Token: 0x0200362C RID: 13868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node17 : Condition
	{
		// Token: 0x0601547C RID: 87164 RVA: 0x0066A562 File Offset: 0x00668962
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601547D RID: 87165 RVA: 0x0066A598 File Offset: 0x00668998
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE35 RID: 60981
		private int opl_p0;

		// Token: 0x0400EE36 RID: 60982
		private int opl_p1;

		// Token: 0x0400EE37 RID: 60983
		private int opl_p2;

		// Token: 0x0400EE38 RID: 60984
		private int opl_p3;
	}
}
