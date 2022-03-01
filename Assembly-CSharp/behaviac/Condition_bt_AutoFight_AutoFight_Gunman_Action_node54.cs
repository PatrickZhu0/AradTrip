using System;

namespace behaviac
{
	// Token: 0x02002588 RID: 9608
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node54 : Condition
	{
		// Token: 0x06013458 RID: 78936 RVA: 0x005BA81D File Offset: 0x005B8C1D
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node54()
		{
			this.opl_p0 = 1200;
		}

		// Token: 0x06013459 RID: 78937 RVA: 0x005BA830 File Offset: 0x005B8C30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE82 RID: 52866
		private int opl_p0;
	}
}
