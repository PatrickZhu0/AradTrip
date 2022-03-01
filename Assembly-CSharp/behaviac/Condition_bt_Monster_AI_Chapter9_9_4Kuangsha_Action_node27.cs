using System;

namespace behaviac
{
	// Token: 0x02003177 RID: 12663
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node27 : Condition
	{
		// Token: 0x06014B85 RID: 84869 RVA: 0x0063D451 File Offset: 0x0063B851
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node27()
		{
			this.opl_p0 = 21543;
		}

		// Token: 0x06014B86 RID: 84870 RVA: 0x0063D464 File Offset: 0x0063B864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4F3 RID: 58611
		private int opl_p0;
	}
}
