using System;

namespace behaviac
{
	// Token: 0x02002292 RID: 8850
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node30 : Condition
	{
		// Token: 0x06012EA4 RID: 77476 RVA: 0x005943CE File Offset: 0x005927CE
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node30()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012EA5 RID: 77477 RVA: 0x005943E4 File Offset: 0x005927E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8AF RID: 51375
		private float opl_p0;
	}
}
