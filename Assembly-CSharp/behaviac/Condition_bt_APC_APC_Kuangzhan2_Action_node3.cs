using System;

namespace behaviac
{
	// Token: 0x02001D90 RID: 7568
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node3 : Condition
	{
		// Token: 0x060124DB RID: 74971 RVA: 0x00557577 File Offset: 0x00555977
		public Condition_bt_APC_APC_Kuangzhan2_Action_node3()
		{
			this.opl_p0 = 9720;
		}

		// Token: 0x060124DC RID: 74972 RVA: 0x0055758C File Offset: 0x0055598C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEC7 RID: 48839
		private int opl_p0;
	}
}
