using System;

namespace behaviac
{
	// Token: 0x02001E00 RID: 7680
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node14 : Condition
	{
		// Token: 0x060125B3 RID: 75187 RVA: 0x0055C717 File Offset: 0x0055AB17
		public Condition_bt_APC_APC_Swordman_test_Action_node14()
		{
			this.opl_p0 = 1509;
		}

		// Token: 0x060125B4 RID: 75188 RVA: 0x0055C72C File Offset: 0x0055AB2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFA2 RID: 49058
		private int opl_p0;
	}
}
