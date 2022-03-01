using System;

namespace behaviac
{
	// Token: 0x02001E8E RID: 7822
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node25 : Condition
	{
		// Token: 0x060126C6 RID: 75462 RVA: 0x00563507 File Offset: 0x00561907
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node25()
		{
			this.opl_p0 = 9740;
		}

		// Token: 0x060126C7 RID: 75463 RVA: 0x0056351C File Offset: 0x0056191C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0B4 RID: 49332
		private int opl_p0;
	}
}
