using System;

namespace behaviac
{
	// Token: 0x0200253D RID: 9533
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node39 : Condition
	{
		// Token: 0x060133C3 RID: 78787 RVA: 0x005B6D89 File Offset: 0x005B5189
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node39()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060133C4 RID: 78788 RVA: 0x005B6D9C File Offset: 0x005B519C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDEB RID: 52715
		private float opl_p0;
	}
}
