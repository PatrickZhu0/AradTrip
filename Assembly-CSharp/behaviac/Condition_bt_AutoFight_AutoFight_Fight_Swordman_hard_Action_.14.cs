using System;

namespace behaviac
{
	// Token: 0x020022AB RID: 8875
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node30 : Condition
	{
		// Token: 0x06012ED2 RID: 77522 RVA: 0x00595632 File Offset: 0x00593A32
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node30()
		{
			this.opl_p0 = 0.76f;
		}

		// Token: 0x06012ED3 RID: 77523 RVA: 0x00595648 File Offset: 0x00593A48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8DC RID: 51420
		private float opl_p0;
	}
}
