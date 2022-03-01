using System;

namespace behaviac
{
	// Token: 0x02001FD7 RID: 8151
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node32 : Condition
	{
		// Token: 0x0601294B RID: 76107 RVA: 0x00571CF2 File Offset: 0x005700F2
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node32()
		{
			this.opl_p0 = 0.42f;
		}

		// Token: 0x0601294C RID: 76108 RVA: 0x00571D08 File Offset: 0x00570108
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C33D RID: 49981
		private float opl_p0;
	}
}
