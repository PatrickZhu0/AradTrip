using System;

namespace behaviac
{
	// Token: 0x0200239D RID: 9117
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node41 : Condition
	{
		// Token: 0x060130A0 RID: 77984 RVA: 0x005A29B9 File Offset: 0x005A0DB9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node41()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060130A1 RID: 77985 RVA: 0x005A29CC File Offset: 0x005A0DCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAC6 RID: 51910
		private float opl_p0;
	}
}
