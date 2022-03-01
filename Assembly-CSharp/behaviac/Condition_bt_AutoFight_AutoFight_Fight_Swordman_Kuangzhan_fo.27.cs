using System;

namespace behaviac
{
	// Token: 0x0200235A RID: 9050
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node54 : Condition
	{
		// Token: 0x06013021 RID: 77857 RVA: 0x0059EF5A File Offset: 0x0059D35A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node54()
		{
			this.opl_p0 = 0.29f;
		}

		// Token: 0x06013022 RID: 77858 RVA: 0x0059EF70 File Offset: 0x0059D370
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA38 RID: 51768
		private float opl_p0;
	}
}
