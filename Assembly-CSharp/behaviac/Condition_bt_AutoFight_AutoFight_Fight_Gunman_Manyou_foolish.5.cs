using System;

namespace behaviac
{
	// Token: 0x02002132 RID: 8498
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node12 : Condition
	{
		// Token: 0x06012BF6 RID: 76790 RVA: 0x00582A96 File Offset: 0x00580E96
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node12()
		{
			this.opl_p0 = 0.26f;
		}

		// Token: 0x06012BF7 RID: 76791 RVA: 0x00582AAC File Offset: 0x00580EAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5E9 RID: 50665
		private float opl_p0;
	}
}
