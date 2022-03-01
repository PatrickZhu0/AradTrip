using System;

namespace behaviac
{
	// Token: 0x02001DAE RID: 7598
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node16 : Condition
	{
		// Token: 0x06012515 RID: 75029 RVA: 0x00558E87 File Offset: 0x00557287
		public Condition_bt_APC_APC_Kuangzhan_Action_node16()
		{
			this.opl_p0 = 7106;
		}

		// Token: 0x06012516 RID: 75030 RVA: 0x00558E9C File Offset: 0x0055729C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF05 RID: 48901
		private int opl_p0;
	}
}
