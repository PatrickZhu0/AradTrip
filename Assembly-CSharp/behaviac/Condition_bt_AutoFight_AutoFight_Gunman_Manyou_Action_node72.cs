using System;

namespace behaviac
{
	// Token: 0x0200261F RID: 9759
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node72 : Condition
	{
		// Token: 0x06013584 RID: 79236 RVA: 0x005C12C9 File Offset: 0x005BF6C9
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node72()
		{
			this.opl_p0 = 1010;
		}

		// Token: 0x06013585 RID: 79237 RVA: 0x005C12DC File Offset: 0x005BF6DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFCF RID: 53199
		private int opl_p0;
	}
}
