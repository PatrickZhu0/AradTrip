using System;

namespace behaviac
{
	// Token: 0x02001D44 RID: 7492
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Gunman_test_Action_node9 : Condition
	{
		// Token: 0x06012449 RID: 74825 RVA: 0x00554365 File Offset: 0x00552765
		public Condition_bt_APC_APC_Gunman_test_Action_node9()
		{
			this.opl_p0 = 1006;
		}

		// Token: 0x0601244A RID: 74826 RVA: 0x00554378 File Offset: 0x00552778
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE3D RID: 48701
		private int opl_p0;
	}
}
