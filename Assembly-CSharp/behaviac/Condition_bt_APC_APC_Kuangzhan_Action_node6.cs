using System;

namespace behaviac
{
	// Token: 0x02001DB3 RID: 7603
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node6 : Condition
	{
		// Token: 0x0601251F RID: 75039 RVA: 0x00559267 File Offset: 0x00557667
		public Condition_bt_APC_APC_Kuangzhan_Action_node6()
		{
			this.opl_p0 = 7106;
		}

		// Token: 0x06012520 RID: 75040 RVA: 0x0055927C File Offset: 0x0055767C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF10 RID: 48912
		private int opl_p0;
	}
}
