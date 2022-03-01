using System;

namespace behaviac
{
	// Token: 0x02001FC7 RID: 8135
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node12 : Condition
	{
		// Token: 0x0601292B RID: 76075 RVA: 0x00571522 File Offset: 0x0056F922
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node12()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x0601292C RID: 76076 RVA: 0x00571538 File Offset: 0x0056F938
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C31D RID: 49949
		private float opl_p0;
	}
}
