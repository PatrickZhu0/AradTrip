using System;

namespace behaviac
{
	// Token: 0x02002514 RID: 9492
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node26 : Condition
	{
		// Token: 0x06013371 RID: 78705 RVA: 0x005B5BC2 File Offset: 0x005B3FC2
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node26()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06013372 RID: 78706 RVA: 0x005B5BD8 File Offset: 0x005B3FD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD94 RID: 52628
		private float opl_p0;
	}
}
