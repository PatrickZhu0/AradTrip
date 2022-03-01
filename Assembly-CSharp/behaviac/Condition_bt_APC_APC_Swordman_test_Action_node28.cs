using System;

namespace behaviac
{
	// Token: 0x02001E0A RID: 7690
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node28 : Condition
	{
		// Token: 0x060125C7 RID: 75207 RVA: 0x0055CCD3 File Offset: 0x0055B0D3
		public Condition_bt_APC_APC_Swordman_test_Action_node28()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x060125C8 RID: 75208 RVA: 0x0055CCE8 File Offset: 0x0055B0E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFB5 RID: 49077
		private int opl_p0;
	}
}
