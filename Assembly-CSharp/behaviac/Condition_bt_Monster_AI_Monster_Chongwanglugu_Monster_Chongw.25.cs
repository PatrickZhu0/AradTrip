using System;

namespace behaviac
{
	// Token: 0x02003612 RID: 13842
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node34 : Condition
	{
		// Token: 0x0601544A RID: 87114 RVA: 0x00668F5B File Offset: 0x0066735B
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node34()
		{
			this.opl_p0 = 5442;
		}

		// Token: 0x0601544B RID: 87115 RVA: 0x00668F70 File Offset: 0x00667370
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE06 RID: 60934
		private int opl_p0;
	}
}
