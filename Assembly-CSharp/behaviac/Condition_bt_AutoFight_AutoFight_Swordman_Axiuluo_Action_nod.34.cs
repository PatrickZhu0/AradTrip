using System;

namespace behaviac
{
	// Token: 0x020028C4 RID: 10436
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node54 : Condition
	{
		// Token: 0x06013AC2 RID: 80578 RVA: 0x005DFAA6 File Offset: 0x005DDEA6
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node54()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013AC3 RID: 80579 RVA: 0x005DFABC File Offset: 0x005DDEBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D521 RID: 54561
		private float opl_p0;
	}
}
