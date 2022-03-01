using System;

namespace behaviac
{
	// Token: 0x02001DDD RID: 7645
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node50 : Condition
	{
		// Token: 0x06012570 RID: 75120 RVA: 0x0055B0C3 File Offset: 0x005594C3
		public Condition_bt_APC_APC_Nianqishi_Action_node50()
		{
			this.opl_p0 = 9701;
		}

		// Token: 0x06012571 RID: 75121 RVA: 0x0055B0D8 File Offset: 0x005594D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF61 RID: 48993
		private int opl_p0;
	}
}
