using System;

namespace behaviac
{
	// Token: 0x020024F9 RID: 9465
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node45 : Condition
	{
		// Token: 0x0601333C RID: 78652 RVA: 0x005B36CE File Offset: 0x005B1ACE
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node45()
		{
			this.opl_p0 = 0.24f;
		}

		// Token: 0x0601333D RID: 78653 RVA: 0x005B36E4 File Offset: 0x005B1AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD5C RID: 52572
		private float opl_p0;
	}
}
