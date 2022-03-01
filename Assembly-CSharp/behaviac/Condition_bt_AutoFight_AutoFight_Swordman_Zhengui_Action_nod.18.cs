using System;

namespace behaviac
{
	// Token: 0x02002993 RID: 10643
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node120 : Condition
	{
		// Token: 0x06013C5A RID: 80986 RVA: 0x005EA073 File Offset: 0x005E8473
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node120()
		{
			this.opl_p0 = 1801;
		}

		// Token: 0x06013C5B RID: 80987 RVA: 0x005EA088 File Offset: 0x005E8488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6C5 RID: 54981
		private int opl_p0;
	}
}
