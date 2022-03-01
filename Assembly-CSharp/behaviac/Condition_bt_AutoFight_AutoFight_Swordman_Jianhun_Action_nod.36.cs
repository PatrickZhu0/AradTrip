using System;

namespace behaviac
{
	// Token: 0x02002933 RID: 10547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node73 : Condition
	{
		// Token: 0x06013B9C RID: 80796 RVA: 0x005E50B1 File Offset: 0x005E34B1
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node73()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B9D RID: 80797 RVA: 0x005E50C4 File Offset: 0x005E34C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D603 RID: 54787
		private float opl_p0;
	}
}
