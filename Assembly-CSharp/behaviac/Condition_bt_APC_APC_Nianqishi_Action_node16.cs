using System;

namespace behaviac
{
	// Token: 0x02001DD8 RID: 7640
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node16 : Condition
	{
		// Token: 0x06012566 RID: 75110 RVA: 0x0055AEB5 File Offset: 0x005592B5
		public Condition_bt_APC_APC_Nianqishi_Action_node16()
		{
			this.opl_p0 = 9705;
		}

		// Token: 0x06012567 RID: 75111 RVA: 0x0055AEC8 File Offset: 0x005592C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF56 RID: 48982
		private int opl_p0;
	}
}
