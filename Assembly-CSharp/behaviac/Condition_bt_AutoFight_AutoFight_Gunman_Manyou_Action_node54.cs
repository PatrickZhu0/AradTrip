using System;

namespace behaviac
{
	// Token: 0x02002611 RID: 9745
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node54 : Condition
	{
		// Token: 0x06013568 RID: 79208 RVA: 0x005C0C65 File Offset: 0x005BF065
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node54()
		{
			this.opl_p0 = 1113;
		}

		// Token: 0x06013569 RID: 79209 RVA: 0x005C0C78 File Offset: 0x005BF078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFB5 RID: 53173
		private int opl_p0;
	}
}
