using System;

namespace behaviac
{
	// Token: 0x02001EFB RID: 7931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node44 : Condition
	{
		// Token: 0x0601279A RID: 75674 RVA: 0x00567E09 File Offset: 0x00566209
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node44()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601279B RID: 75675 RVA: 0x00567E1C File Offset: 0x0056621C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C190 RID: 49552
		private float opl_p0;
	}
}
