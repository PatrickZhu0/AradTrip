using System;

namespace behaviac
{
	// Token: 0x02003610 RID: 13840
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node32 : Condition
	{
		// Token: 0x06015446 RID: 87110 RVA: 0x00668E9A File Offset: 0x0066729A
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node32()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06015447 RID: 87111 RVA: 0x00668ED0 File Offset: 0x006672D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE01 RID: 60929
		private int opl_p0;

		// Token: 0x0400EE02 RID: 60930
		private int opl_p1;

		// Token: 0x0400EE03 RID: 60931
		private int opl_p2;

		// Token: 0x0400EE04 RID: 60932
		private int opl_p3;
	}
}
