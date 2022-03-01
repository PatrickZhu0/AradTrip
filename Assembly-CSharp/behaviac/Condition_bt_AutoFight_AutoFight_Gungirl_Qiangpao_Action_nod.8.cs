using System;

namespace behaviac
{
	// Token: 0x0200251D RID: 9501
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node110 : Condition
	{
		// Token: 0x06013383 RID: 78723 RVA: 0x005B5F8D File Offset: 0x005B438D
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node110()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013384 RID: 78724 RVA: 0x005B5FA0 File Offset: 0x005B43A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDA7 RID: 52647
		private float opl_p0;
	}
}
