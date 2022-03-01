using System;

namespace behaviac
{
	// Token: 0x02001FEE RID: 8174
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node7 : Condition
	{
		// Token: 0x06012978 RID: 76152 RVA: 0x00573366 File Offset: 0x00571766
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node7()
		{
			this.opl_p0 = 0.22f;
		}

		// Token: 0x06012979 RID: 76153 RVA: 0x0057337C File Offset: 0x0057177C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C36B RID: 50027
		private float opl_p0;
	}
}
