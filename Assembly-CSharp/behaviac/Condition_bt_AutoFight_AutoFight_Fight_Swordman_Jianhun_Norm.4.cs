using System;

namespace behaviac
{
	// Token: 0x020022EE RID: 8942
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node97 : Condition
	{
		// Token: 0x06012F55 RID: 77653 RVA: 0x0059A46E File Offset: 0x0059886E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node97()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012F56 RID: 77654 RVA: 0x0059A484 File Offset: 0x00598884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C968 RID: 51560
		private float opl_p0;
	}
}
