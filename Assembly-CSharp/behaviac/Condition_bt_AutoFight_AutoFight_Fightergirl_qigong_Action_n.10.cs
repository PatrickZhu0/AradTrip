using System;

namespace behaviac
{
	// Token: 0x02001EFF RID: 7935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node11 : Condition
	{
		// Token: 0x060127A2 RID: 75682 RVA: 0x00567FB9 File Offset: 0x005663B9
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node11()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060127A3 RID: 75683 RVA: 0x00567FCC File Offset: 0x005663CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C198 RID: 49560
		private float opl_p0;
	}
}
