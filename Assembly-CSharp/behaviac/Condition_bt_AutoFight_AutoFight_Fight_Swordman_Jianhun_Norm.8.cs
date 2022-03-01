using System;

namespace behaviac
{
	// Token: 0x020022F3 RID: 8947
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node4 : Condition
	{
		// Token: 0x06012F5F RID: 77663 RVA: 0x0059A6ED File Offset: 0x00598AED
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node4()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012F60 RID: 77664 RVA: 0x0059A700 File Offset: 0x00598B00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C978 RID: 51576
		private float opl_p0;
	}
}
