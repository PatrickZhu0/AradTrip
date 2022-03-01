using System;

namespace behaviac
{
	// Token: 0x020023CC RID: 9164
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node10 : Condition
	{
		// Token: 0x060130FE RID: 78078 RVA: 0x005A583A File Offset: 0x005A3C3A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node10()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060130FF RID: 78079 RVA: 0x005A5850 File Offset: 0x005A3C50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB30 RID: 52016
		private float opl_p0;
	}
}
