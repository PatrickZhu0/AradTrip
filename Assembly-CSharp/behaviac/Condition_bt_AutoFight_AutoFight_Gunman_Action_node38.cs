using System;

namespace behaviac
{
	// Token: 0x02002584 RID: 9604
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node38 : Condition
	{
		// Token: 0x06013450 RID: 78928 RVA: 0x005BA665 File Offset: 0x005B8A65
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node38()
		{
			this.opl_p0 = 1102;
		}

		// Token: 0x06013451 RID: 78929 RVA: 0x005BA678 File Offset: 0x005B8A78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE7A RID: 52858
		private int opl_p0;
	}
}
