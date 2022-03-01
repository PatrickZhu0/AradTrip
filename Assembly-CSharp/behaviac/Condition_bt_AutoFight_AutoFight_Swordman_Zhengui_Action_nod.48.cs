using System;

namespace behaviac
{
	// Token: 0x020029BB RID: 10683
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node40 : Condition
	{
		// Token: 0x06013CAA RID: 81066 RVA: 0x005EB231 File Offset: 0x005E9631
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node40()
		{
			this.opl_p0 = 1809;
		}

		// Token: 0x06013CAB RID: 81067 RVA: 0x005EB244 File Offset: 0x005E9644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D718 RID: 55064
		private int opl_p0;
	}
}
