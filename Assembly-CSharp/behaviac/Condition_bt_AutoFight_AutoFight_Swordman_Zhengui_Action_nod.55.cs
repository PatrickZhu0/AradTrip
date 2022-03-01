using System;

namespace behaviac
{
	// Token: 0x020029C4 RID: 10692
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node57 : Condition
	{
		// Token: 0x06013CBC RID: 81084 RVA: 0x005EB5F9 File Offset: 0x005E99F9
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node57()
		{
			this.opl_p0 = 1810;
		}

		// Token: 0x06013CBD RID: 81085 RVA: 0x005EB60C File Offset: 0x005E9A0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D72B RID: 55083
		private int opl_p0;
	}
}
