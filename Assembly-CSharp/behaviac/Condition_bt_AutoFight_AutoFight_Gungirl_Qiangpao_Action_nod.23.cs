using System;

namespace behaviac
{
	// Token: 0x02002531 RID: 9521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node31 : Condition
	{
		// Token: 0x060133AB RID: 78763 RVA: 0x005B6861 File Offset: 0x005B4C61
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node31()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060133AC RID: 78764 RVA: 0x005B6874 File Offset: 0x005B4C74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDD3 RID: 52691
		private float opl_p0;
	}
}
