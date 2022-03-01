using System;

namespace behaviac
{
	// Token: 0x020040CF RID: 16591
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_ActionBT_node6 : Condition
	{
		// Token: 0x060168F4 RID: 92404 RVA: 0x006D4E9B File Offset: 0x006D329B
		public Condition_bt_ActionBT_node6()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060168F5 RID: 92405 RVA: 0x006D4EAC File Offset: 0x006D32AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010139 RID: 65849
		private int opl_p0;
	}
}
