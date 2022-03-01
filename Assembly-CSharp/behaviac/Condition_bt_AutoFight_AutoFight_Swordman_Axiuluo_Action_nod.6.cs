using System;

namespace behaviac
{
	// Token: 0x020028A0 RID: 10400
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node11 : Condition
	{
		// Token: 0x06013A7A RID: 80506 RVA: 0x005DE9E9 File Offset: 0x005DCDE9
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node11()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013A7B RID: 80507 RVA: 0x005DE9FC File Offset: 0x005DCDFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4D6 RID: 54486
		private float opl_p0;
	}
}
