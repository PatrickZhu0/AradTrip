using System;

namespace behaviac
{
	// Token: 0x020023A4 RID: 9124
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node28 : Condition
	{
		// Token: 0x060130AE RID: 77998 RVA: 0x005A30A1 File Offset: 0x005A14A1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node28()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060130AF RID: 77999 RVA: 0x005A30B4 File Offset: 0x005A14B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAD4 RID: 51924
		private float opl_p0;
	}
}
