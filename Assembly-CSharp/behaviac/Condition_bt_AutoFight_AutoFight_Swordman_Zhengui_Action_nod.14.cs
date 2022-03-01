using System;

namespace behaviac
{
	// Token: 0x0200298E RID: 10638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node125 : Condition
	{
		// Token: 0x06013C50 RID: 80976 RVA: 0x005E9E5F File Offset: 0x005E825F
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node125()
		{
			this.opl_p0 = 1811;
		}

		// Token: 0x06013C51 RID: 80977 RVA: 0x005E9E74 File Offset: 0x005E8274
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6BA RID: 54970
		private int opl_p0;
	}
}
