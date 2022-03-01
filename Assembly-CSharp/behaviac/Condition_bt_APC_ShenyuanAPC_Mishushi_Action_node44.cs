using System;

namespace behaviac
{
	// Token: 0x02001E9D RID: 7837
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node44 : Condition
	{
		// Token: 0x060126E4 RID: 75492 RVA: 0x00563B91 File Offset: 0x00561F91
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node44()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060126E5 RID: 75493 RVA: 0x00563BA4 File Offset: 0x00561FA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0D3 RID: 49363
		private float opl_p0;
	}
}
