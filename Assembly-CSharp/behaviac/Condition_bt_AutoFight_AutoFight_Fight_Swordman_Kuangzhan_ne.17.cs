using System;

namespace behaviac
{
	// Token: 0x020023A8 RID: 9128
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node55 : Condition
	{
		// Token: 0x060130B6 RID: 78006 RVA: 0x005A36AD File Offset: 0x005A1AAD
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node55()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060130B7 RID: 78007 RVA: 0x005A36C0 File Offset: 0x005A1AC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CADE RID: 51934
		private float opl_p0;
	}
}
