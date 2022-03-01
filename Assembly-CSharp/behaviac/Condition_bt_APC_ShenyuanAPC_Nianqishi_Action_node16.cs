using System;

namespace behaviac
{
	// Token: 0x02001EAB RID: 7851
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node16 : Condition
	{
		// Token: 0x060126FE RID: 75518 RVA: 0x005648FC File Offset: 0x00562CFC
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node16()
		{
			this.opl_p0 = 9705;
		}

		// Token: 0x060126FF RID: 75519 RVA: 0x00564910 File Offset: 0x00562D10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0EB RID: 49387
		private int opl_p0;
	}
}
