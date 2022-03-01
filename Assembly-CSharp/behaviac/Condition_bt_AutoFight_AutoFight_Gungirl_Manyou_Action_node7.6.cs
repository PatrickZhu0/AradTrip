using System;

namespace behaviac
{
	// Token: 0x02002510 RID: 9488
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node75 : Condition
	{
		// Token: 0x0601336A RID: 78698 RVA: 0x005B4396 File Offset: 0x005B2796
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node75()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601336B RID: 78699 RVA: 0x005B43AC File Offset: 0x005B27AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD8D RID: 52621
		private float opl_p0;
	}
}
