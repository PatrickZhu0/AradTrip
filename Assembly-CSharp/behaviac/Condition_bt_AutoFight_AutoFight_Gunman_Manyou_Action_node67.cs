using System;

namespace behaviac
{
	// Token: 0x02002616 RID: 9750
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node67 : Condition
	{
		// Token: 0x06013572 RID: 79218 RVA: 0x005C0E5F File Offset: 0x005BF25F
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node67()
		{
			this.opl_p0 = 1010;
		}

		// Token: 0x06013573 RID: 79219 RVA: 0x005C0E74 File Offset: 0x005BF274
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFBE RID: 53182
		private int opl_p0;
	}
}
