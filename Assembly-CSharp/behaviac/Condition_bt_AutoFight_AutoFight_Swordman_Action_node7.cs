using System;

namespace behaviac
{
	// Token: 0x0200286E RID: 10350
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node7 : Condition
	{
		// Token: 0x06013A19 RID: 80409 RVA: 0x005DC64B File Offset: 0x005DAA4B
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node7()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x06013A1A RID: 80410 RVA: 0x005DC660 File Offset: 0x005DAA60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D473 RID: 54387
		private int opl_p0;
	}
}
