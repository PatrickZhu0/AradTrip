using System;

namespace behaviac
{
	// Token: 0x02001E9A RID: 7834
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node56 : Condition
	{
		// Token: 0x060126DE RID: 75486 RVA: 0x00563A23 File Offset: 0x00561E23
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node56()
		{
			this.opl_p0 = 9743;
		}

		// Token: 0x060126DF RID: 75487 RVA: 0x00563A38 File Offset: 0x00561E38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0CC RID: 49356
		private int opl_p0;
	}
}
