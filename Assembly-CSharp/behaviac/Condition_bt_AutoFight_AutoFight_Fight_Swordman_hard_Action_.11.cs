using System;

namespace behaviac
{
	// Token: 0x020022A6 RID: 8870
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node24 : Condition
	{
		// Token: 0x06012EC8 RID: 77512 RVA: 0x0059543A File Offset: 0x0059383A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node24()
		{
			this.opl_p0 = 0.78f;
		}

		// Token: 0x06012EC9 RID: 77513 RVA: 0x00595450 File Offset: 0x00593850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8D1 RID: 51409
		private float opl_p0;
	}
}
