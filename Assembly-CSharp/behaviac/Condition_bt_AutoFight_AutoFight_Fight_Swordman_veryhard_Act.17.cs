using System;

namespace behaviac
{
	// Token: 0x0200246D RID: 9325
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node67 : Condition
	{
		// Token: 0x0601322A RID: 78378 RVA: 0x005AD751 File Offset: 0x005ABB51
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node67()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x0601322B RID: 78379 RVA: 0x005AD764 File Offset: 0x005ABB64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC4F RID: 52303
		private int opl_p0;
	}
}
