using System;

namespace behaviac
{
	// Token: 0x0200228B RID: 8843
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node21 : Condition
	{
		// Token: 0x06012E96 RID: 77462 RVA: 0x00594087 File Offset: 0x00592487
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node21()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012E97 RID: 77463 RVA: 0x0059409C File Offset: 0x0059249C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8A1 RID: 51361
		private int opl_p0;
	}
}
