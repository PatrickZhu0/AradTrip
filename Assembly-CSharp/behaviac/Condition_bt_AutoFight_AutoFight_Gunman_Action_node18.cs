using System;

namespace behaviac
{
	// Token: 0x02002574 RID: 9588
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node18 : Condition
	{
		// Token: 0x06013430 RID: 78896 RVA: 0x005B9EDD File Offset: 0x005B82DD
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node18()
		{
			this.opl_p0 = 1014;
		}

		// Token: 0x06013431 RID: 78897 RVA: 0x005B9EF0 File Offset: 0x005B82F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE5A RID: 52826
		private int opl_p0;
	}
}
