using System;

namespace behaviac
{
	// Token: 0x02003609 RID: 13833
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14 : Condition
	{
		// Token: 0x06015438 RID: 87096 RVA: 0x00668B95 File Offset: 0x00666F95
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14()
		{
			this.opl_p0 = 5438;
		}

		// Token: 0x06015439 RID: 87097 RVA: 0x00668BA8 File Offset: 0x00666FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDF3 RID: 60915
		private int opl_p0;
	}
}
