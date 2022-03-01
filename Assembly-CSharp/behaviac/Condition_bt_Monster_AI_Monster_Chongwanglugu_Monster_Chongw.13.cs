using System;

namespace behaviac
{
	// Token: 0x02003602 RID: 13826
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2 : Condition
	{
		// Token: 0x0601542A RID: 87082 RVA: 0x0066888A File Offset: 0x00666C8A
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601542B RID: 87083 RVA: 0x006688C0 File Offset: 0x00666CC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDE2 RID: 60898
		private int opl_p0;

		// Token: 0x0400EDE3 RID: 60899
		private int opl_p1;

		// Token: 0x0400EDE4 RID: 60900
		private int opl_p2;

		// Token: 0x0400EDE5 RID: 60901
		private int opl_p3;
	}
}
