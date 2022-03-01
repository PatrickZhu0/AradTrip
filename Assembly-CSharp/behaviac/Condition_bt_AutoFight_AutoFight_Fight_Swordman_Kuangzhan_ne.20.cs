using System;

namespace behaviac
{
	// Token: 0x020023AC RID: 9132
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node65 : Condition
	{
		// Token: 0x060130BE RID: 78014 RVA: 0x005A3CB9 File Offset: 0x005A20B9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node65()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060130BF RID: 78015 RVA: 0x005A3CCC File Offset: 0x005A20CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAE8 RID: 51944
		private float opl_p0;
	}
}
