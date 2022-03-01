using System;

namespace behaviac
{
	// Token: 0x02002222 RID: 8738
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node42 : Condition
	{
		// Token: 0x06012DCE RID: 77262 RVA: 0x0058E664 File Offset: 0x0058CA64
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node42()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012DCF RID: 77263 RVA: 0x0058E678 File Offset: 0x0058CA78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7C5 RID: 51141
		private float opl_p0;
	}
}
