using System;

namespace behaviac
{
	// Token: 0x020022B3 RID: 8883
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node97 : Condition
	{
		// Token: 0x06012EE1 RID: 77537 RVA: 0x0059618E File Offset: 0x0059458E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node97()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012EE2 RID: 77538 RVA: 0x005961A4 File Offset: 0x005945A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8EF RID: 51439
		private float opl_p0;
	}
}
