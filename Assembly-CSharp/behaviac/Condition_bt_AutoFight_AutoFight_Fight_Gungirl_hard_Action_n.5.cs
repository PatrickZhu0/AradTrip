using System;

namespace behaviac
{
	// Token: 0x02001FAF RID: 8111
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node12 : Condition
	{
		// Token: 0x060128FC RID: 76028 RVA: 0x00570312 File Offset: 0x0056E712
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node12()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060128FD RID: 76029 RVA: 0x00570328 File Offset: 0x0056E728
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2EE RID: 49902
		private float opl_p0;
	}
}
