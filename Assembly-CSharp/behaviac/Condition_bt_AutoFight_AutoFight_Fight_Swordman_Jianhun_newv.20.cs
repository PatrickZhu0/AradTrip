using System;

namespace behaviac
{
	// Token: 0x020022C8 RID: 8904
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node39 : Condition
	{
		// Token: 0x06012F0B RID: 77579 RVA: 0x00597701 File Offset: 0x00595B01
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node39()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012F0C RID: 77580 RVA: 0x00597714 File Offset: 0x00595B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C91F RID: 51487
		private float opl_p0;
	}
}
