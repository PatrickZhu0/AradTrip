using System;

namespace behaviac
{
	// Token: 0x020036AF RID: 13999
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node12 : Condition
	{
		// Token: 0x06015578 RID: 87416 RVA: 0x0067015A File Offset: 0x0066E55A
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node12()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015579 RID: 87417 RVA: 0x00670190 File Offset: 0x0066E590
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF4C RID: 61260
		private int opl_p0;

		// Token: 0x0400EF4D RID: 61261
		private int opl_p1;

		// Token: 0x0400EF4E RID: 61262
		private int opl_p2;

		// Token: 0x0400EF4F RID: 61263
		private int opl_p3;
	}
}
