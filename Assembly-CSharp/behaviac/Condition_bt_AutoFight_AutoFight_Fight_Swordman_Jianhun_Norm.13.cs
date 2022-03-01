using System;

namespace behaviac
{
	// Token: 0x020022FA RID: 8954
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node44 : Condition
	{
		// Token: 0x06012F6D RID: 77677 RVA: 0x0059AD07 File Offset: 0x00599107
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node44()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06012F6E RID: 77678 RVA: 0x0059AD1C File Offset: 0x0059911C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C984 RID: 51588
		private float opl_p0;
	}
}
