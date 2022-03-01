using System;

namespace behaviac
{
	// Token: 0x02002561 RID: 9569
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node105 : Condition
	{
		// Token: 0x0601340B RID: 78859 RVA: 0x005B7CE1 File Offset: 0x005B60E1
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node105()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601340C RID: 78860 RVA: 0x005B7CF4 File Offset: 0x005B60F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE33 RID: 52787
		private float opl_p0;
	}
}
