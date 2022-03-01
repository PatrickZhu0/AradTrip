using System;

namespace behaviac
{
	// Token: 0x02002519 RID: 9497
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node47 : Condition
	{
		// Token: 0x0601337B RID: 78715 RVA: 0x005B5DD9 File Offset: 0x005B41D9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node47()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601337C RID: 78716 RVA: 0x005B5DEC File Offset: 0x005B41EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD9F RID: 52639
		private float opl_p0;
	}
}
