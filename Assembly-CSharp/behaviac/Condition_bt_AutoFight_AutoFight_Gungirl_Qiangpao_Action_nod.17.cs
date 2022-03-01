using System;

namespace behaviac
{
	// Token: 0x02002529 RID: 9513
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node52 : Condition
	{
		// Token: 0x0601339B RID: 78747 RVA: 0x005B64A9 File Offset: 0x005B48A9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node52()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601339C RID: 78748 RVA: 0x005B64BC File Offset: 0x005B48BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDBF RID: 52671
		private float opl_p0;
	}
}
